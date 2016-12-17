using ASRCsCodeathonProject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRCsCodeathonProject
{
    class WinAppKestrelTracker : WinApp_A
    {
        public WinAppKestrelTracker()
        {
            initialize();
        }

        private void initialize()
        {
            winAppProcessName = "KestrelCommunicator";
        }

        public String getWinAppProcessName() { return winAppProcessName; }

        //Turns data recieved from the windowStringProcessor into the data struct we use
        public override SerializableDataStruct processWindowData(List<String> dataSet)
        {
            SerializableDataStruct kestrelWindowData = new SerializableDataStruct();
            DateTime date_time;

            //This is going to be a very crude way to get the data points since for now, we retrieve live data in a poor way...
            String date_time_s = getDataForProperty(dataSet, "Last sample time:");
            String date = date_time_s.Split(' ')[0];
            String time = date_time_s.Split(' ')[1];
            String ampm = date_time_s.Split(' ')[2];
            date_time = new DateTime(
                Convert.ToInt32(date.Split('/')[2]), 
                Convert.ToInt32(date.Split('/')[0]), 
                Convert.ToInt32(date.Split('/')[1]),
                Convert.ToInt32(time.Split(':')[0]),
                Convert.ToInt32(time.Split(':')[1]),
                Convert.ToInt32(time.Split(':')[2]));

            kestrelWindowData.date_time = date_time;
            kestrelWindowData.wind_speed = Convert.ToDouble(getDataForProperty(dataSet, "WIND SPEED"));
            kestrelWindowData.temp = Convert.ToDouble(getDataForProperty(dataSet, "TEMP"));
            kestrelWindowData.rel_hum = Convert.ToDouble(getDataForProperty(dataSet, "REL. HUMIDITY"));
            kestrelWindowData.bar = Convert.ToDouble(getDataForProperty(dataSet, "PRESSURE"));
            kestrelWindowData.head_wind = Convert.ToDouble(getDataForProperty(dataSet, "HEAD WIND"));
            kestrelWindowData.wind_chill = Convert.ToDouble(getDataForProperty(dataSet, "CHILL"));
            kestrelWindowData.wet_bulb = Convert.ToDouble(getDataForProperty(dataSet, "WET BULB"));
            kestrelWindowData.alt = Convert.ToDouble(getDataForProperty(dataSet, "ALTITUDE"));
            kestrelWindowData.cross_wind = Convert.ToDouble(getDataForProperty(dataSet, "CROSS WIND"));
            kestrelWindowData.heat_index = Convert.ToDouble(getDataForProperty(dataSet, "HEAT INDEX"));
            kestrelWindowData.den_alt = Convert.ToDouble(getDataForProperty(dataSet, "DENSITY ALT."));
            kestrelWindowData.cross_wind = Convert.ToDouble(getDataForProperty(dataSet, "CROSS WIND"));
            kestrelWindowData.dew_point = Convert.ToDouble(getDataForProperty(dataSet, "DEW POINT"));

            /*for (int i = 0; i < dataSet.Count; i++)
            {
                Console.WriteLine(dataSet[i]);
            }*/

            //Console.WriteLine(kestrelWindowData.ToString());
            //Console.ReadKey();

            return kestrelWindowData;
        }

        /*
         * The way this data is given, the index of the data value is: property index-2
         */
        private String getDataForProperty(List<String> dataSet, String property)
        {
            String value = null;

            for (int i = 0; i < dataSet.Count; i++)
            {
                if(dataSet[i].Equals(property))
                {
                    //bounds checking
                    if (i >= 2)
                    {
                        //the time property is weird and is in a different indicie compared to the other properties
                        if (property.Equals("Last sample time:"))
                        {
                            value = dataSet[i + 1];
                        }
                        else
                        {
                            value = dataSet[i - 2];
                        }
                    }
                }
            }

            return value;
        }
    }
}
