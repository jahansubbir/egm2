namespace EgmGenerator.Models
{
    public class FreightSegment
    {
        public string Value { get; set; }
        public string Currency { get; set; }
        public IndicatorSegment IndicatorSegment { get; set; }

        
    }
    public class IndicatorSegment
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}