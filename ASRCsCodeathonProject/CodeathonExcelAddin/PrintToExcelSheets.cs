using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using ASRCsCodeathonProject;

namespace CodeathonExcelAddin
{
    public static class PrintToExcelSheets
    {
        public static void printDataSetToExcel(Excel.Workbook workbook, ListSerializableDataStruct lsds, int sheetNumber)
        {
            Excel.Worksheet newDataSetSheet = null;

            Excel.Sheets excel_sheets = workbook.Worksheets;
            newDataSetSheet = excel_sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            newDataSetSheet.Name = "New Data Set" + sheetNumber;
            int i = 0;
            //foreach (string dataType in lsds.dataTypes)
            //{
            //    newDataSetSheet.Cells[1, i++].Value2 = dataType;
            //}
            
            for (i = 2; i < lsds.getCount()+2; i++)
            {
                int j = 1;
                SerializableDataStruct sds = lsds.getSDS(i - 2);
                newDataSetSheet.Cells[i, j++].Value2 = sds.wind_speed;
                newDataSetSheet.Cells[i, j++].Value2 = sds.cross_wind;
                newDataSetSheet.Cells[i, j++].Value2 = sds.head_wind;
                newDataSetSheet.Cells[i, j++].Value2 = sds.temp;
                newDataSetSheet.Cells[i, j++].Value2 = sds.wind_chill;
                newDataSetSheet.Cells[i, j++].Value2 = sds.rel_hum;
                newDataSetSheet.Cells[i, j++].Value2 = sds.heat_index;
                newDataSetSheet.Cells[i, j++].Value2 = sds.dew_point;
                newDataSetSheet.Cells[i, j++].Value2 = sds.wet_bulb;
                newDataSetSheet.Cells[i, j++].Value2 = sds.bar;
                newDataSetSheet.Cells[i, j++].Value2 = sds.alt;
                newDataSetSheet.Cells[i, j++].Value2 = sds.den_alt;
            }
        }
    }
}
