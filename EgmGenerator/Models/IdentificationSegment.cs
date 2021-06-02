using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.Models
{
  public  class IdentificationSegment
    {
        public string VoyageNumber { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string BolReference { get; set; }
        public CustomsOffice CustomsOffice { get; set; }
    }
}
