using System;
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

        public ListSerializableDataStruct()
        {
            sds_list = new List<ASRCsCodeathonProject.SerializableDataStruct>();
        }

        // The value to serialize.
        private string myProperty_value;

        public string MyProperty
        {
            get { return myProperty_value; }
            set { myProperty_value = value; }
        }


        // The special constructor is used to deserialize values.
        public ListSerializableDataStruct(SerializationInfo info, StreamingContext context)
        {
            sds_list = (List<SerializableDataStruct>)info.GetValue("sds_list", typeof(List<SerializableDataStruct>));
        }

        // Implement this method to serialize data. The method is called 
        // on serialization.
        // Use the AddValue method to specify serialized values.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("sds_list", sds_list);
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
            for (int i = 0; i < sds_list.Count; i++)
            {
                // Go through input list
                for (int j = 0; j < in_lsds.getCount(); j++)
                {
                    if (!(sds_list[i].Equals(in_lsds.getCurrentIndexSds(j))))
                    {
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

        public override string ToString()
        {
            return "Data Set: " + sds.ToString();
        }
    }

}