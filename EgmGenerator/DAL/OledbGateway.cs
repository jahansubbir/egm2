using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgmGenerator.DAL
{
    class OledbGateway
    {
        private string connectionString = "";
        protected string Query { get; set; }
        protected OleDbConnection Connection { get; set; }
        protected OleDbCommand Command { get; set; }
        protected OleDbDataReader Reader { get; set; }
        public OledbGateway()
        {

        }
        public OleDbConnection Connect(string fileName)
        {
            if (Path.GetExtension(fileName).CompareTo(".xls") == 0)
            {
                connectionString = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;';"; //for below excel 2007  
            }

            else
            {
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES';"; //for above excel 2007

            }
            Connection = new OleDbConnection(connectionString);
            return Connection;
        }
    }

}


