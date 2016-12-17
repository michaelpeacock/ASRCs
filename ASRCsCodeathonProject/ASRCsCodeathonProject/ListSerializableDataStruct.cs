using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Globalization;
using System.Collections;

[Serializable()]
class ListSerializableDataStruct : ISerializable
{
    public ASRCsCodeathonProject.SerializableDataStruct sds;
    public List<ASRCsCodeathonProject.SerializableDataStruct> sds_list;

    public ListSerializableDataStruct()
    {
    }

    // The value to serialize.
    private string myProperty_value;

    public string MyProperty
    {
        get { return myProperty_value; }
        set { myProperty_value = value; }
    }

    // Implement this method to serialize data. The method is called 
    // on serialization.
    // Use the AddValue method to specify serialized values.
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
    }

    // The special constructor is used to deserialize values.
    public ListSerializableDataStruct(SerializationInfo info, StreamingContext context)
    {
        // Reset the property value using the GetValue method.
        myProperty_value = (string)info.GetValue("props", typeof(string));
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
        ListSerializableDataStruct temp = in_lsds;
        // Go through base list
        for(int i = 0; i < sds_list.Count; i++)
        {
            // Go through input list
            for(int j = 0; j < in_lsds.getCount(); j++)
            {
               if (!(sds_list[i].Equals(in_lsds.getCurrentIndexSds(j)))) {
                    sds_list.Add(in_lsds.getCurrentIndexSds(j));
               }
            }
        }
    }

    // Calculate the averages of each category
    public void getAverages()
    {
        // Call each average function...
        double wind_speed = getAvgWS();
        double cross_wind = getAvgCW();
        double head_wind = getAvgHW();
        double temp = getAvgTP();
        double wind_chill = getAvgWC();
        double rel_hum = getAvgRH();
        double heat_index = getAvgHI();
        double dew_point = getAvgDP();
        double wet_bulb = getAvgWB();
        double bar_pre = getAvgBP();
        double alt = getAvgAL();
        double den_alt = getAvgDA();
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
        double avgCs = 0;

        for (int i = 0; i < sds_list.Count; i++)
        {
            avgCs += sds_list[i].cross_wind;
        }

        return (avgCs / sds_list.Count);
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
        return "Data Set: " + sds.ToString();
    }
}
