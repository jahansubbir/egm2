using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.Models
{
   public class BolSpecificSegment
    {
        public string LineNumber { get; set; }
        public string SubLineNumber { get; set; }
        public string Status { get; set; }
        public string PreviousDocumentReference { get; set; }
        public string BolNature { get; set; }
        public string UniqueCarrierReference { get; set; }
        public int TotalNumberOfContainers { get; set; }
        public double TotalGrossMassManifested { get; set; }
        public double VolumeInCubicMeters { get; set; }
        public int NumberOfSubBols { get; set; }
        public BolTypeSegment BolTypeSegment { get; set; }
        public ExporterSegment ExporterSegment { get; set; }
        public ConsigneeSegment ConsigneeSegment { get; set; }
        public NotifySegment NotifySegment { get; set; }
        public PlaceOfLoadingSegment PlaceOfLoadingSegment { get; set; }
        public PlaceOfUnloadingSegment PlaceOfUnloadingSegment { get; set; }
        public PackagesSegment PackagesSegment { get; set; }
        public ShippingSegment ShippingSegment { get; set; }
        public GoodsSegment GoodsSegment { get; set; }
        public FreightSegment FreightSegment { get; set; }
        public CustomsSegment CustomsSegment { get; set; }
        public TransportSegment TransportSegment   { get; set; }
        public InsuranceSegment InsuranceSegment { get; set; }
        public SealsSegment SealsSegment { get; set; }
        public InformationSegment InformationSegment { get; set; }
        public OperationsSegment OperationsSegment { get; set; }




    }
}
