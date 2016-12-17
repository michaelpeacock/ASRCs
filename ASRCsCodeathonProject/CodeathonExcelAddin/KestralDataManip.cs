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

        public KestralDataManip(Excel.Worksheet sheet, Excel.Workbook workbook, KestrelDataAddInRibbon ribbon)
        {
            this.sheet = sheet;
            this.workbook = workbook;
            this.excelRibbon = ribbon;
            InitializeComponent();
        }

        private void readData_Click(object sender, EventArgs e)
        {
            List<SerializableDataStruct> list;
            list = ProcessExcelData.getDataSet(sheet.UsedRange, workbook);
            label1.Text = "temp: " + list[0].temp;
        }
    }
}
