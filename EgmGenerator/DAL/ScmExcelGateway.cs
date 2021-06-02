using EgmGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.DAL
{
    class ScmExcelGateway:OceanExcelGateway
    {
        public override Dictionary<string, Egm> GetEgms(string fileName, string sheetName)
        {
            Dictionary<string, Egm> egmList = new Dictionary<string, Egm>();
            Query = @"SELECT * FROM [" + sheetName + "$] WHERE BL_FCR<>''";
            Connection = Connect(fileName);
            Connection.Open();
            Command = new OleDbCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            //   dt.Load(reader: Reader);
            while (Reader.Read())
            {
                Egm egm = new Egm();
                //egm.DocumentNo = Reader["BOOKING NO"]?.ToString();
                IdentificationSegment identificationSegment = new IdentificationSegment()
                {
                    VoyageNumber = Reader["VOYAGE"]?.ToString(),
                    BolReference = Reader["BL_FCR"]?.ToString().Replace(" ",""),
                                       
                    CustomsOffice = new CustomsOffice() { Code = "301", Name = "Custom House,Chittagong" },
                    DateOfDeparture = (Reader["DATE OF DEPARTURE"] != DBNull.Value) ? Convert.ToDateTime(Reader["DATE OF DEPARTURE"]) : DateTime.MinValue
                };
                egm.IdentificationSegment = identificationSegment;


                BolSpecificSegment bolSpecificSegment = new BolSpecificSegment
                {
                    LineNumber = "1",
                    Status = "FCL",
                    BolNature = "22",
                    NumberOfSubBols = 0,
                    PreviousDocumentReference=Reader["MASTER_BL"].ToString(),

                    //BolTypeSegment = new BolTypeSegment() { Code = Reader["BL TYPE"].ToString()},
                    ExporterSegment = new ExporterSegment() { Name = Reader["SHIPPER"].ToString().Replace("&", "and") },
                    ConsigneeSegment = new ConsigneeSegment() { Name = Reader["CONSIGNEE"].ToString().Replace("&", "and") },
                    NotifySegment = new NotifySegment() ,
                    PlaceOfLoadingSegment = new PlaceOfLoadingSegment() { Code = "BDCGP", Name = "Chittagong" },
                    PackagesSegment = new PackagesSegment()
                    {
                        NumberOfPackages = (Reader["PKGS"] != DBNull.Value) ? Convert.ToInt32(Reader["PKGS"]) : 0,
                        PackageTypeName = Reader["PKGCODE"].ToString(),
                        PackageTypeCode = PackageTypeCodes.GetPackageTypes().FirstOrDefault(a => a.Name.ToLower().Trim() == Reader["PKGCODE"].ToString().ToLower().Trim())?.Code
                    },


                };
                //bolSpecificSegment.BolTypeSegment = new BolTypeSegment() { Code = "HSB", Name = "House Sea Bill" };
                //bolSpecificSegment.ExporterSegment.Name = Reader["Consignor Name"]?.ToString();
                //bolSpecificSegment.ExporterSegment.Address = Reader["Consignor Address"]?.ToString();
                //bolSpecificSegment.ConsigneeSegment.Name = Reader["Consignee Name"]?.ToString();
                //bolSpecificSegment.ConsigneeSegment.Address = Reader["Consignee Address"]?.ToString();
                bolSpecificSegment.NotifySegment.Name = Reader["NOTIFY NAME"]?.ToString();
                bolSpecificSegment.NotifySegment.Address = Reader["NOTIFY ADDRESS"]?.ToString();

                bolSpecificSegment.BolTypeSegment = new BolTypeSegment() { Code = Reader["BL TYPE"].ToString() };

                switch (bolSpecificSegment.BolTypeSegment.Code)
                {
                    case "HSB":
                        bolSpecificSegment.BolTypeSegment.Name = "House Sea Bill";
                        break;
                    case "MSB":
                        bolSpecificSegment.BolTypeSegment.Name = "Master Sea Bill";
                        break;
                }

                egm.BolSpecificSegment = bolSpecificSegment;

                Containers containers = new Containers()
                {
                    Idt = Reader["CONTAINER"]?.ToString(),

                };
                var containerData = new ContainerData();

                containerData.Number = (Reader["PKGS"] != DBNull.Value) ? Convert.ToInt32(Reader["PKGS"]) : 0;
                containerData.Identification = Reader["CONTAINER"]?.ToString();
                containerData.Type = Reader["CONTAINER ISO CODE"]?.ToString();
                containerData.Seals = Reader["SEAL"]?.ToString();
                containerData.Full = Reader["Status"]?.ToString();
                containerData.SealingParty = Reader["CONTAINER STATION"]?.ToString();// "102DICD";
                containerData.GoodsWeight = (Reader["CWeight"] != DBNull.Value) ? Convert.ToDouble(Reader["CWeight"]) : 0;
                containerData.Cbm= (Reader["CBM"] != DBNull.Value) ? Convert.ToDouble(Reader["CBM"]) : 0;
                containers.ContainerData = containerData;

                //    egm.Containers = new List<Containers>();
                //    egm.Containers.Add(containers);
                if (egmList.ContainsKey(identificationSegment.BolReference))
                {
                    egmList[identificationSegment.BolReference].Containers.Add(containers);
                }
                else
                {
                    egm.Containers = new List<Containers>();
                    egm.Containers.Add(containers);
                    egmList.Add(identificationSegment.BolReference, egm);
                }


            }
            Reader.Close();
            Connection.Close();
            return egmList;
        }

    }
}
