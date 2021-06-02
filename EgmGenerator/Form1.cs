using EgmGenerator.BLL;
using EgmGenerator.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgmGenerator
{
    public partial class Form1 : Form
    {
        string entity = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileOk += FileDialog_FileOk;
            fileDialog.ShowDialog();
        }

        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            FilePathTextBox.Text = dialog.FileName;

        }

        private void EgmButton_Click(object sender, EventArgs e)
        {
            OceanExcelGateway excelGateway = null;
            
            if (OceanRadio.Checked)
            {
                excelGateway = new OceanExcelGateway(); }
            else if (ScmRadio.Checked)
            {
                excelGateway = new ScmExcelGateway();
            }

            if (excelGateway != null)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowDialog();
                var savefolderDialog = folderBrowserDialog.SelectedPath;


                string fileName = FilePathTextBox.Text;
                string sheetName = SheetNameTextBox.Text;
                EgmPreparator egmPreparator = new EgmPreparator(excelGateway);
                //var egm = excelGateway.GetEgms(fileName, sheetName);
                egmPreparator.Prepare(fileName, sheetName, savefolderDialog);
                MessageBox.Show("Done!");
            }
            else
                MessageBox.Show("Select Ocean or SCM");
        }

        private void OceanRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OceanRadio.Checked)
            {
                ScmRadio.Checked = false;
            }
        }

        private void ScmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ScmRadio.Checked)
            {
                OceanRadio.Checked = false;
            }

        }
    }
}
