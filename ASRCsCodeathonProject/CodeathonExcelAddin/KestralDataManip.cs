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
        ListSerializableDataStruct list, tempLoadList,liveList;
        Excel.Worksheet AutoCollectDataSheet;
        WindowHandlerManager whm;
        private Timer timer;
        int sheetNumber = 1;
        bool autoCollecting = false;


        public KestralDataManip(Excel.Worksheet sheet, Excel.Workbook workbook, KestrelDataAddInRibbon ribbon, bool dataOnSheet)
        {
            this.sheet = sheet;
            this.workbook = workbook;
            this.excelRibbon = ribbon;
            whm = new WindowHandlerManager();
            liveList = new ListSerializableDataStruct();
            Excel.Worksheet AutoCollectDataSheet = null;

            Excel.Sheets excel_sheets = workbook.Worksheets;
            AutoCollectDataSheet = excel_sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            AutoCollectDataSheet.Name = "Auto Collect";
            
            InitializeComponent();
            if (!dataOnSheet)
                readData.Enabled = false;
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
            readData.Enabled = true;
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
            readData.Enabled = true;
        }

        private void mergeAnotherLoadedSet_Click(object sender, EventArgs e)
        {
            loadinList(true);
            list.addList(tempLoadList);
            tempLoadList = null;
            PrintToExcelSheets.printDataSetToExcel(workbook, list, sheetNumber++);
            readData.Enabled = true;
        }
       
               
        public void InitTimer()
        {
            
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000; // in miliseconds
            timer.Start();
            autoCollecting = true;
            autocollection.Text = "Stop Auto Collecting";
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            liveList.add(whm.getKestrelAppData());
            
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                if (sheet.Name == "Auto Collect")
                    AutoCollectDataSheet = sheet;
            }
            for (int i = 4; i < liveList.dataTypesLabels.Count; i++)
            {
                AutoCollectDataSheet.Cells[1, i - 3].Value2 = liveList.dataTypesLabels[i];
            }

            for (int i = 2; i < liveList.getCount() + 2; i++)
            {
                int j = 1;
                SerializableDataStruct sds = liveList.getSDS(i - 2);
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.wind_speed;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.cross_wind;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.head_wind;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.temp;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.wind_chill;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.rel_hum;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.heat_index;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.dew_point;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.wet_bulb;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.bar;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.alt;
                AutoCollectDataSheet.Cells[i, j++].Value2 = sds.den_alt;
            }
        }

        public Excel.Worksheet getAutoSheet()
        {
            return AutoCollectDataSheet;
        }

        private void autocollection_Click(object sender, EventArgs e)
        {
            if (!autoCollecting)
            {
                
                InitTimer();
            }
            else
            {
                timer.Stop();
                autocollection.Text = "Start Auto Collecting";
                autoCollecting = false;
            }
        }

        private void saveAutoCollect_Click(object sender, EventArgs e)
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

                    bformatter.Serialize(stream, liveList);
                    stream.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                }
                Invalidate();
            }
        }
    }
}
