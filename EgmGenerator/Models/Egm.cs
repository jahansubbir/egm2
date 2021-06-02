using EgmGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator
{
   public class Egm
    {
       
        public IdentificationSegment IdentificationSegment { get; set; }
        public BolSpecificSegment BolSpecificSegment { get; set; }
        public List<Containers> Containers { get; set; }

       
    }
}
