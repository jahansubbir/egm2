using EgmGenerator;
using EgmGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace EgmGenerator.BLL
{
    public class XmlCreator
    {

        public void Create(string filePath, Egm egm)
        {

            //XElement containetInfo = new XElement("c");
            //var totalNoOfPackages = igm.BolReferences.Sum(a => a.NumberOfPackages);

            //var hbl = igm.BolReferences[0];


            try
            {

                XDocument doc = new XDocument(
                    new XElement("AsycudaWorld_Manifest",
                        new XElement("Identification_segment",
                            new XElement("Voyage_number", egm.IdentificationSegment.VoyageNumber),
                            new XElement("Date_of_departure", egm.IdentificationSegment.DateOfDeparture.ToString("MM/dd/yy")),
                            new XElement("Bol_reference", egm.IdentificationSegment.BolReference),

                            new XElement("Customs_office_segment",
                            new XElement("Code", egm.IdentificationSegment.CustomsOffice.Code),
                            new XElement("Name", egm.IdentificationSegment.CustomsOffice.Name)
                            )

                     ),
                        new XElement(
                            "Bol_specific_segment",

                            new XElement("Line_number", egm.BolSpecificSegment.LineNumber),
                            new XElement("Sub_line_number", egm.BolSpecificSegment.SubLineNumber),
                            new XElement("Status", egm.BolSpecificSegment.Status),
                            new XElement("Previous_document_reference", egm.BolSpecificSegment.PreviousDocumentReference),
                            new XElement("Bol_Nature", egm.BolSpecificSegment.BolNature),
                            new XElement("Unique_carrier_reference", null),
                            new XElement("Total_number_of_containers", egm.Containers.Count),
                            new XElement("Total_gross_mass_manifested", egm.Containers.Sum(a => a.ContainerData.GoodsWeight)),
                            new XElement("Volume_in_cubic_meters", egm.Containers.Sum(a=>a.ContainerData.Cbm)),
                            new XElement("Number_of_sub_bols", 0),

                            new XElement("Bol_type_segment",
                            new XElement("Code", egm.BolSpecificSegment.BolTypeSegment.Code),
                            new XElement("Name", egm.BolSpecificSegment.BolTypeSegment.Name)
                        ),
                        new XElement("Exporter_segment",
                         new XElement("Code", egm.BolSpecificSegment.ExporterSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.ExporterSegment?.Name),
                         new XElement("Address", egm.BolSpecificSegment.ExporterSegment?.Address)
                        ),
                        new XElement("Consignee_segment",
                         new XElement("Code", egm.BolSpecificSegment.ConsigneeSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.ConsigneeSegment?.Name),
                         new XElement("Address", egm.BolSpecificSegment.ConsigneeSegment?.Address)
                        ),
                        new XElement("Notify_segment",
                         new XElement("Code", egm.BolSpecificSegment.NotifySegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.NotifySegment?.Name),
                         new XElement("Address", egm.BolSpecificSegment.NotifySegment?.Address)
                        ),
                        new XElement("Place_of_loading_segment",
                         new XElement("Code", egm.BolSpecificSegment.PlaceOfLoadingSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.PlaceOfLoadingSegment?.Name)
                         ),
                         new XElement("Place_of_unloading_segment",
                         new XElement("Code", egm.BolSpecificSegment.PlaceOfUnloadingSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.PlaceOfUnloadingSegment?.Name)
                         ),
                         new XElement("Packages_segment",
                         new XElement("Package_type_code", egm.BolSpecificSegment.PackagesSegment?.PackageTypeCode),
                         new XElement("Package_type_name", egm.BolSpecificSegment.PackagesSegment?.PackageTypeName),
                         new XElement("Number_of_packages", egm.BolSpecificSegment.PackagesSegment?.NumberOfPackages)
                         ),
                         new XElement("Shipping_segment",
                         new XElement("Shipping_marks", egm.BolSpecificSegment.ShippingSegment?.ShippingMarks)
                         ),
                         new XElement("Goods_segment",
                         new XElement("Goods_description", egm.BolSpecificSegment.GoodsSegment?.GoodsDescription)
                         ),
                         new XElement("Freight_segment",
                         new XElement("Value", egm.BolSpecificSegment.FreightSegment?.Value),
                         new XElement("Currency", egm.BolSpecificSegment.FreightSegment?.Currency),
                         new XElement("Indicator_segment",
                         new XElement("Code", egm.BolSpecificSegment.FreightSegment?.IndicatorSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.FreightSegment?.IndicatorSegment?.Name)
                         )),
                         new XElement("Customs_segment",
                          new XElement("Value", egm.BolSpecificSegment.CustomsSegment?.Value),
                         new XElement("Currency", egm.BolSpecificSegment.CustomsSegment?.Currency)
                         ),
                         new XElement("Transport_segment",
                          new XElement("Value", egm.BolSpecificSegment.TransportSegment?.Value),
                         new XElement("Currency", egm.BolSpecificSegment.TransportSegment?.Currency)
                         ),
                         new XElement("Insurance_segment",
                          new XElement("Value", egm.BolSpecificSegment.InsuranceSegment?.Value),
                         new XElement("Currency", egm.BolSpecificSegment.InsuranceSegment?.Currency)
                         ),
                         new XElement("Seals_segment",
                         new XElement("Number_of_seals", egm.BolSpecificSegment.SealsSegment?.NumberOfSeals),
                         new XElement("Marks_of_seals", egm.BolSpecificSegment.SealsSegment?.MarksofSeals),
                         new XElement("Sealing_party_code", egm.BolSpecificSegment.SealsSegment?.SealingPartyCode),
                         new XElement("Sealing_party_name", egm.BolSpecificSegment.SealsSegment?.SealingPartyName)
                         ),
                         new XElement("Information_segment",
                         new XElement("Information_part_a", egm.BolSpecificSegment.InformationSegment?.InformationPartA)
                         ),
                         new XElement("Operations_segment",
                         new XElement("Packages_remaining", egm.BolSpecificSegment.OperationsSegment?.PackagesRemaining),
                         new XElement("Gross_mass_remaining", egm.BolSpecificSegment.OperationsSegment?.GrossMassRemaining),
                         new XElement("Location_segment",
                         new XElement("Code", egm.BolSpecificSegment.OperationsSegment?.LocationSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.OperationsSegment?.LocationSegment?.Name),
                         new XElement("Information", egm.BolSpecificSegment.OperationsSegment?.LocationSegment?.Information)
                         ),
                         new XElement("Onward_transport_segment",
                         new XElement("Transit_segment",
                         new XElement("Customs_office_code", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TransitSegment?.CustomsOfficeCode),
                         new XElement("Customs_office_name", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TransitSegment?.CustomsOfficeName),
                         new XElement("Document_reference", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TransitSegment?.DocumentReference)
                         ),
                         new XElement("Transhipment_segment",
                         new XElement("Transipment_location_code", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TranshipmentSegment?.TransipmentLocationCode),
                         new XElement("Transipment_location_name", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TranshipmentSegment?.TranshipmentLocationName),
                         new XElement("Document_reference", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.TranshipmentSegment?.DocumentReference)
                         ),
                         new XElement("Onward_carrier_segment",
                         new XElement("Code", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.OnwardCarrierSegment?.Code),
                         new XElement("Name", egm.BolSpecificSegment.OperationsSegment?.OnwardTransportSegment?.OnwardCarrierSegment?.Name)
                         )
                         )
                         )



                     ),new XElement(GetContainerDetails(egm.Containers)
                        )));
                   DeleteCNode(doc, doc.Root);
                doc.Save(filePath);
            }
            catch (Exception exception)
            {
                var x = exception.GetBaseException();
            }

        }

        private void DeleteCNode(XDocument doc, XElement element)
        {

            while (doc.Descendants("c").Count() > 0)
            {
                var x = doc.Descendants("c").First();
                x.AddAfterSelf(x.Nodes());
                x.Remove();
            }

        }

        private XElement GetContainerDetails(List<Containers> containerList)
        {
            XElement containetInfo = new XElement("c");
            foreach(var item in containerList)
            {


                var containerSegment = new XElement("Containers",
                    new XElement("IDT", item.Idt),
                    new XElement("Container_Data",
                    new XElement("Number", item.ContainerData.Number),
                    new XElement("Type", item.ContainerData.Type),
                    new XElement("Identification", item.ContainerData.Identification),
                    new XElement("Seals", item.ContainerData.Seals),
                    new XElement("Full", item.ContainerData.Full),
                    new XElement("Sealing_Party", item.ContainerData.SealingParty),
                    new XElement("Empty_weight", item.ContainerData.EmptyWeight),
                    new XElement("Goods_weight", item.ContainerData.GoodsWeight)
                    )
                    );
                containetInfo.Add(containerSegment);


            }
            return
                containetInfo;
        }

        
    }
}
