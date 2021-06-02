using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.Models
{
   public class Containers
    {
        public string Idt { get; set; }
        public ContainerData ContainerData { get; set; }
    }

    public class ContainerData
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Identification { get; set; }
        public string Seals { get; set; }
        public string Full { get; set; }
        public string SealingParty { get; set; }
        public string EmptyWeight { get; set; }
        public double GoodsWeight { get; set; }
        public double Cbm { get; set; }

    }
}
