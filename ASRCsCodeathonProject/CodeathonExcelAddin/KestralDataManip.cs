using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ASRCsCodeathonProject;

namespace CodeathonExcelAddin
{
    public partial class KestralDataManip : UserControl
    {
        Excel.Worksheet sheet;
        Excel.Workbook workbook;
        KestrelDataAddInRibbon excelRibbon;
        List<SerializableDataStruct> dataset;
        ListSerializableDataStruct list, tempLoadList;
        int sheetNumber = 1;

        public KestralDataManip(Excel.Worksheet sheet, Excel.Workbook workbook, KestrelDataAddInRibbon ribbon)
        {
            this.sheet = sheet;
            this.workbook = workbook;
            this.excelRibbon = ribbon;
            InitializeComponent();
        }

        private void readData_Click(object sender, EventArgs e)
        {
            list = ProcessExcelData.getDataSet(sheet.UsedRange, workbook);
        }

        private void serializeData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog.ShowNewFolderButton = false;
            saveFileDialog.DefaultExt = "osl";
            saveFileDialog.Filter = "osl files (*.osl)|*.osl";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
            saveFileDialog.InitialDirectory = folderBrowserDialog.SelectedPath;
            saveFileDialog.FileName = null;
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;
                try
                {

                    Stream stream = File.Open(saveFileName, FileMode.Create);
                    BinaryFormatter bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, list);
                    stream.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                }
                Invalidate();

            }

       // Cancel button was pressed. 
            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private void loadSerializedData_Click(object sender, EventArgs e)
        {
            loadinList(false);
        }

        private void loadinList(bool alreadyLoadedOne)
        {
            OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog.ShowNewFolderButton = false;
            openFileDialog.DefaultExt = "osl";
            openFileDialog.Filter = "osl files (*.osl)|*.osl";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
            openFileDialog.InitialDirectory = folderBrowserDialog.SelectedPath;
            openFileDialog.FileName = null;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string openFileName = openFileDialog.FileName;
                try
                {

                    Stream stream = File.Open(openFileName, FileMode.Open);
                    BinaryFormatter bformatter = new BinaryFormatter();
                    if (!alreadyLoadedOne)
                    {
                        list = (ListSerializableDataStruct)bformatter.Deserialize(stream);
                    }
                    else
                        tempLoadList = (ListSerializableDataStruct)bformatter.Deserialize(stream);
                    stream.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                }
                Invalidate();

            }

            // Cancel button was pressed. 
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            if (!alreadyLoadedOne)
                PrintToExcelSheets.printDataSetToExcel(workbook, list, sheetNumber++);
        }

        private void mergeDataSets_Click(object sender, EventArgs e)
        {
            list.addList(ProcessExcelData.getDataSet(sheet.UsedRange, workbook));
            PrintToExcelSheets.printDataSetToExcel(workbook, list, sheetNumber++);
        }

        private void mergeAnotherLoadedSet_Click(object sender, EventArgs e)
        {
            loadinList(true);
            list.addList(tempLoadList);
            tempLoadList = null;
            PrintToExcelSheets.printDataSetToExcel(workbook, list, sheetNumber++);
        }
    }
}
