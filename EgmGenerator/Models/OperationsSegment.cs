namespace EgmGenerator.Models
{
    public class OperationsSegment
    {
        public int PackagesRemaining { get; set; }
        public double GrossMassRemaining { get; set; }
        public LocationSegment LocationSegment { get; set; }
        public OnwardTransportSegment OnwardTransportSegment { get; set; }

    }

    public class OnwardTransportSegment
    {
        public TransitSegment TransitSegment { get; set; }
        public TranshipmentSegment TranshipmentSegment { get; set; }
        public OnwardCarrierSegment OnwardCarrierSegment { get; set; }
    }

    public class OnwardCarrierSegment
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }

    public class TranshipmentSegment
    {
        public string TransipmentLocationCode { get; set; }
        public string TranshipmentLocationName { get; set; }
        public string DocumentReference { get; set; }

    }

    public class TransitSegment
    {
        public string CustomsOfficeCode { get; set; }
        public string CustomsOfficeName { get; set; }
        public string DocumentReference { get; set; }

    }

    public class LocationSegment
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }

    }
}