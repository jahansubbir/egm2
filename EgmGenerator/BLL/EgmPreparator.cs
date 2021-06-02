using EgmGenerator.DAL;
using EgmGenerator.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.BLL
{
    class EgmPreparator
    {
        private readonly OceanExcelGateway excelGateway;

        public EgmPreparator(OceanExcelGateway excelGateway)
        {
            this.excelGateway = excelGateway;
        }
        public void Prepare(string fileName,string sheet, string savefolderDialog)
        {
            XmlCreator xmlCreator = new XmlCreator();
            var egmList = excelGateway.GetEgms(fileName, sheet);
            foreach (var item in egmList)
            {
                xmlCreator.Create(savefolderDialog+@"\" + item.Key + ".xml", item.Value);
            }
        }
    }
}
