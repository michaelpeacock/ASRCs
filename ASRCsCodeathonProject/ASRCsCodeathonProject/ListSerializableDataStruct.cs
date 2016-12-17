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
    public SerializableDataStruct sds;
    public List<SerializableDataStruct> sds_list;

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

    // Get current index in the list
    public SerializableDataStruct getCurrentIndexSds(int index)
    {
        return sds_list[index];
    }

    // Add a SerializableDataStruct to the list
    public void add(SerializableDataStruct in_sds)
    {
        sds_list.Add(in_sds);
    }

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
        // For each add, remove duplicates as you go
    }

    public override string ToString()
    {
        return "Data Set: " + sds.ToString();
    }
}
