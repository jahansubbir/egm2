using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using EgmGenerator.Models;
using System.Data;

namespace EgmGenerator.DAL
{
    class OceanExcelGateway : OledbGateway
    {
        public  virtual Dictionary<string,Egm> GetEgms(string fileName, string sheetName)
        {
            Dictionary<string,Egm> egmList = new Dictionary<string, Egm>();
            Query = "SELECT * FROM [" + sheetName + "$]";
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
                    VoyageNumber = Reader["Voyage_Number"]?.ToString(),
                    BolReference = Reader["Bol_reference"]?.ToString(),
                    CustomsOffice = new CustomsOffice() { Code = "301", Name = "Custom House,Chittagong" },
                    DateOfDeparture = (Reader["Date_of_departure"] != DBNull.Value) ? Convert.ToDateTime(Reader["Date_of_departure"]) : DateTime.MinValue
                };
                egm.IdentificationSegment = identificationSegment;


                BolSpecificSegment bolSpecificSegment = new BolSpecificSegment
                {
                    LineNumber = "1",
                    Status = "FCL",
                    BolNature = "22",
                    NumberOfSubBols = 0,

                    //BolTypeSegment = new BolTypeSegment() { Code = Reader["BL TYPE"].ToString()},
                    ExporterSegment = new ExporterSegment() { Name = Reader["Shipper"].ToString().Replace("&", "and") },
                    ConsigneeSegment = new ConsigneeSegment() { Name = Reader["CONSIGNEE"].ToString().Replace("&", "and") },
                    NotifySegment = new NotifySegment(),
                    PlaceOfLoadingSegment = new PlaceOfLoadingSegment() { Code = "BDCGP", Name = "Chittagong" },
                    //PackagesSegment = new PackagesSegment()
                    //{
                    //    NumberOfPackages =(Reader["PKGS"]!=DBNull.Value)? Convert.ToInt32(Reader["PKGS"]):0,
                    //    PackageTypeName = Reader["PKGCODE"].ToString(),
                    //    PackageTypeCode = PackageTypeCodes.GetPackageTypes().FirstOrDefault(a => a.Name.ToLower().Trim() == Reader["PKGCODE"].ToString().ToLower().Trim())?.Code
                    //},


                };
                //bolSpecificSegment.BolTypeSegment = new BolTypeSegment() { Code = "HSB", Name = "House Sea Bill" };
                bolSpecificSegment.ExporterSegment.Name = Reader["Consignor Name"]?.ToString();
                bolSpecificSegment.ExporterSegment.Address = Reader["Consignor Address"]?.ToString();
                bolSpecificSegment.ConsigneeSegment.Name = Reader["Consignee Name"]?.ToString();
                bolSpecificSegment.ConsigneeSegment.Address = Reader["Consignee Address"]?.ToString();
                bolSpecificSegment.NotifySegment.Name = Reader["Notify Name"]?.ToString();
                bolSpecificSegment.NotifySegment.Address = Reader["Notify Address"]?.ToString();

                bolSpecificSegment.BolTypeSegment = new BolTypeSegment() { Code = Reader["BL TYPE"].ToString() };
                switch (bolSpecificSegment.BolTypeSegment.Code)
                {
                    //case "HSB":
                    //    bolSpecificSegment.BolTypeSegment.Name = "House Sea Bill";
                    //    break;
                    case "MSB":
                        bolSpecificSegment.BolTypeSegment.Name = "Master Sea Bill";
                        break;
                }
                egm.BolSpecificSegment = bolSpecificSegment;

                //Containers containers = new Containers()
                //{
                //    Idt = Reader["CONTAINER"]?.ToString(),

                //};
                var containerData = new ContainerData();

                //containerData.Number = (Reader["PKGS"] != DBNull.Value) ? Convert.ToInt32(Reader["PKGS"]) : 0;
                //containerData.Identification = Reader["CONTAINER"]?.ToString();
                //containerData.Type = Reader["ISO"]?.ToString();
                //containerData.Seals = Reader["Seal"]?.ToString();
                containerData.Full = Reader["Status"]?.ToString();
                containerData.SealingParty = Reader["Station"].ToString();
                //containerData.GoodsWeight = (Reader["CWeight"] != DBNull.Value) ? Convert.ToDouble(Reader["CWeight"]) : 0;
                //containers.ContainerData = containerData;

            //    egm.Containers = new List<Containers>();
            //    egm.Containers.Add(containers);
                if (egmList.ContainsKey(identificationSegment.BolReference))
                {
                  //  egmList[identificationSegment.BolReference].Containers.Add(containers);
                }
                else
                {
                    egm.Containers = new List<Containers>();
                //    egm.Containers.Add(containers);
                    egmList.Add(identificationSegment.BolReference, egm);
                }

                
            }
            Reader.Close();
            Connection.Close();
            return egmList;
        }
    }
}
