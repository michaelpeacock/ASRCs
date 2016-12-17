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
    public static class ProcessExcelData
    {
        public static List<SerializableDataStruct> getDataSet(Excel.Range used_range, Excel.Workbook workbook)
        {
            List<SerializableDataStruct> DataSet = new List<SerializableDataStruct>();
            int maxRow = used_range.Rows.Count;
            int maxColumn = used_range.Columns.Count;

            List<string> config = new List<string>();

            for (int row = 1; row <= maxRow; row++)
            {
                if (row == 1)
                {
                    for (int column = 1; column <= maxColumn; column++)
                    {
                        config.Add((string)used_range[row, column].Value2);
                    }
                    row++;
                }
                else
                {
                    SerializableDataStruct newRecord = new SerializableDataStruct();
                    for (int column = 1; column <= maxColumn; column++)
                    {
                        object value = used_range[row, column].Value2;

                        if (config[column -1] == "FORMATTED DATE-TIME")
                        {
                            value = used_range[row, column].Value;
                            DateTime dateTime = (DateTime)value;
                        }
                        else if (config[column -1] == "DT")
                        {
                            double timeInSecs = (double)value;
                            newRecord.time_seconds = timeInSecs;
                        }
                        else if (config[column -1] == "MG")
                        {
                            string mg = (string)value;
                            newRecord.mag_dir = mg;
                        }
                        else if (config[column -1] == "TR")
                        {
                            string mg = (string)value;
                            newRecord.true_dir = mg;
                        }
                        else if (config[column -1] == "WS")
                        {
                            double ws = (double)value;
                            newRecord.wind_speed = ws;
                        }
                        else if (config[column -1] == "CW")
                        {
                            double cw = (double)value;
                            newRecord.cross_wind = cw;
                        }
                        else if (config[column -1] == "HW")
                        {
                            double hw = (double)value;
                            newRecord.head_wind = hw;
                        }
                        else if (config[column -1] == "TP")
                        {
                            double tp = (double)value;
                            newRecord.temp = tp;
                        }
                        else if (config[column -1] == "WC")
                        {
                            double wc = (double)value;
                            newRecord.wind_chill = wc;
                        }
                        else if (config[column -1] == "RH")
                        {
                            double rh = (double)value;
                            newRecord.rel_hum = rh;
                        }
                        else if (config[column -1] == "HI")
                        {
                            double hi = (double)value;
                            newRecord.heat_index = hi;
                        }
                        else if (config[column -1] == "DP")
                        {
                            double dp = (double)value;
                            newRecord.dew_point = dp;
                        }
                        else if (config[column -1] == "WB")
                        {
                            double wb = (double)value;
                            newRecord.wet_bulb = wb;
                        }
                        else if (config[column -1] == "BP")
                        {
                            double bp = (double)value;
                            newRecord.bar = bp;
                        }
                        else if (config[column -1] == "AL")
                        {
                            double al = (double)value;
                            newRecord.alt = al;
                        }
                        else if (config[column -1] == "DA")
                        {
                            double da = (double)value;
                            newRecord.den_alt = da;
                        }
                    }
                    DataSet.Add(newRecord);
                }
            }
            return DataSet;
        }
    }

        
}
