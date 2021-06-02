namespace EgmGenerator.Models
{
    public class CustomsOffice
    {
        public string Code { get; set; }
        public string  Name { get; set; }
        public CustomsOffice()
        {
            Code = 301.ToString();
            Name = "Custom House,Chittagong";
        }
    }
}