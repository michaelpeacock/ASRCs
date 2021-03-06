﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Globalization;
using System.Collections;

namespace ASRCsCodeathonProject
{
    [Serializable()]
    public class ListSerializableDataStruct : ISerializable
    {
        public ASRCsCodeathonProject.SerializableDataStruct sds;
        public List<ASRCsCodeathonProject.SerializableDataStruct> sds_list;
        public List<string> dataTypesLabels;

        public ListSerializableDataStruct()
        {
            sds_list = new List<ASRCsCodeathonProject.SerializableDataStruct>();
            setupDataTypeLabels();
        }

        // The special constructor is used to deserialize values.
        public ListSerializableDataStruct(SerializationInfo info, StreamingContext context)
        {
            sds_list = (List<SerializableDataStruct>)info.GetValue("sds_list", typeof(List<SerializableDataStruct>));
            setupDataTypeLabels();
            
        }

        // Implement this method to serialize data. The method is called 
        // on serialization.
        // Use the AddValue method to specify serialized values.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("sds_list", sds_list);
            
        }

        private void setupDataTypeLabels()
        {
            dataTypesLabels = new List<string>();
            dataTypesLabels.Add("Date-Time");
            dataTypesLabels.Add("Seconds");
            dataTypesLabels.Add("MAG Comp");
            dataTypesLabels.Add("true Comp");
            dataTypesLabels.Add("Windspeed");
            dataTypesLabels.Add("Crosswind");
            dataTypesLabels.Add("headwind");
            dataTypesLabels.Add("temp");
            dataTypesLabels.Add("wind chill");
            dataTypesLabels.Add("rel hum");
            dataTypesLabels.Add("heat index");
            dataTypesLabels.Add("dew point");
            dataTypesLabels.Add("wet bulb");
            dataTypesLabels.Add("pressure");
            dataTypesLabels.Add("altitude");
            dataTypesLabels.Add("den alt");
        }

        // Get the size of the list
        public int getCount()
        {
            int count = sds_list.Count;
            return count;
        }

        // Get the current SerializableDataStruct in the list
        public ASRCsCodeathonProject.SerializableDataStruct getCurrentIndexSds(int index)
        {
            return sds_list[index];
        }

        // Add a SerializableDataStruct to the list
        public void add(ASRCsCodeathonProject.SerializableDataStruct in_sds)
        {
            sds_list.Add(in_sds);
        }

        // Add a new list to the current list, ignoring duplicate entries
        public void addList(ListSerializableDataStruct in_lsds)
        {
            for (int i = 0; i < in_lsds.getCount(); i++ )
            {
                sds_list.Add(in_lsds.getSDS(i));
            }
        }

        public SerializableDataStruct getSDS(int index)
        {
            return sds_list[index];
        }

        public void setTypeList(List<string> in_typesList)
        {
            dataTypesLabels = in_typesList;
        }
    

    // Calculate the averages of each category
    public List<double> getAverages()
    {
        List<double> aves = new List<double>();
        // Call each average function...
        aves.Add(getAvgWS());
        aves.Add(getAvgCW());
        aves.Add(getAvgHW());
        aves.Add(getAvgTP());
        aves.Add(getAvgWC());
        aves.Add(getAvgRH());
        aves.Add(getAvgHI());
        aves.Add(getAvgDP());
        aves.Add(getAvgWB());
        aves.Add(getAvgBP());
        aves.Add(getAvgAL());
        aves.Add(getAvgDA());

        return aves;
    }

    // Calculate average wind speed
    public double getAvgWS()
    {
        double avgWs = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgWs += sds_list[i].wind_speed;
        }

        return (avgWs / sds_list.Count);
    }

    // Calculate average cross wind
    public double getAvgCW()
    {
        double avgCw = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgCw += sds_list[i].cross_wind;
        }

        return (avgCw / sds_list.Count);
    }

    // Calculate average head wind
    public double getAvgHW()
    {
        double avgHw = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgHw += sds_list[i].head_wind;
        }

        return (avgHw / sds_list.Count);
    }

    // Calculate average temperature
    public double getAvgTP()
    {
        double avgTp = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgTp += sds_list[i].temp;
        }

        return (avgTp / sds_list.Count);
    }

    // Calculate average wind chill
    public double getAvgWC()
    {
        double avgWc = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgWc += sds_list[i].wind_chill;
        }

        return (avgWc / sds_list.Count);
    }

    // Calculate average relative humidity
    public double getAvgRH()
    {
        double avgRh = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgRh += sds_list[i].rel_hum;
        }

        return (avgRh / sds_list.Count);
    }

    // Calculate average heat index
    public double getAvgHI()
    {
        double avgHi = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgHi += sds_list[i].heat_index;
        }

        return (avgHi / sds_list.Count);
    }

    // Calculate average dew point
    public double getAvgDP()
    {
        double avgDp = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgDp += sds_list[i].dew_point;
        }

        return (avgDp / sds_list.Count);
    }

    // Calculate average wet bulb
    public double getAvgWB()
    {
        double avgWb = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgWb += sds_list[i].wet_bulb;
        }

        return (avgWb / sds_list.Count);
    }

    // Calculate average barometric pressure
    public double getAvgBP()
    {
        double avgBp = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgBp += sds_list[i].bar;
        }

        return (avgBp / sds_list.Count);
    }

    // Calculate average altitude
    public double getAvgAL()
    {
        double avgAl = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgAl += sds_list[i].alt;
        }

        return (avgAl / sds_list.Count);
    }

    // Calculate average density altitude
    public double getAvgDA()
    {
        double avgDa = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgDa += sds_list[i].den_alt;
        }

        return (avgDa / sds_list.Count);
    }

    public override string ToString()
    {
        string dataset = "";
        for (int i = 0; i < sds_list.Count(); i++)
        {
            dataset += sds_list[i].ToString() + "\n";
        }
        return "Data Set:" + dataset;
    }
  }
}