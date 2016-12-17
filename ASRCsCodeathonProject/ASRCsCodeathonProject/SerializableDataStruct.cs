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
class SerializableDataStruct : ISerializable
{
    string date;
    string time;
    string mag_dir;
    string true_dir;
    double wind_speed;
    double cross_wind;
    double head_wind;
    double temp;
    double wind_chill;
    double rel_hum;
    double heat_index;
    double dew_point;
    double wet_bulb;
    double bar;
    double alt;
    double den_alt;

    DateTime parsedDate;
    DateTime parsedTime;

    public SerializableDataStruct(string in_date, string in_time, string in_mag_dir, string in_true_dir, double in_wind_speed, 
                            double in_cross_wind, double in_head_wind, double in_temp, double in_wind_chill, double in_rel_hum, 
                            double in_heat_index, double in_dew_point, double in_wet_bulb, double in_bar, double in_alt, double in_den_alt)
    {
        if (DateTime.TryParseExact(in_date, "MM/dd/yyyy", null, DateTimeStyles.None, out parsedDate))
            date = in_date.Substring(0, 9);      
        else      
            date = "ERROR";
      

        if (DateTime.TryParseExact(in_time, "tt:h:mm:ss", null, DateTimeStyles.None, out parsedTime))      
            time = in_time.Substring(11, 21);   
        else      
            time = "ERROR";
       

        if (in_mag_dir != null)      
            mag_dir = in_mag_dir;      
        else      
            mag_dir = "NULL";


        if (in_true_dir != null)
            true_dir = in_true_dir;
        else
            true_dir = "NULL";

        wind_speed = in_wind_speed;

        cross_wind = in_cross_wind;

        head_wind = in_head_wind;

        temp = in_temp;

        wind_chill = in_wind_chill;

        rel_hum = in_rel_hum;

        heat_index = in_heat_index;

        dew_point = in_dew_point;

        wet_bulb = in_wet_bulb;

        bar = in_bar;

        alt = in_alt;

        den_alt = in_den_alt;
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
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Use the AddValue method to specify serialized values.
        info.AddValue("date", date);
        info.AddValue("time", time);
        info.AddValue("mag_dir", mag_dir);
        info.AddValue("true_dir", true_dir);
        info.AddValue("wind_speed", wind_speed);
        info.AddValue("cross_wind", cross_wind);
        info.AddValue("head_wind", head_wind);
        info.AddValue("temp", temp);
        info.AddValue("wind_chill", wind_chill);
        info.AddValue("rel_hum", rel_hum);
        info.AddValue("heat_index", heat_index);
        info.AddValue("dew_point", dew_point);
        info.AddValue("wet_bulb", wet_bulb);
        info.AddValue("bar", bar);
        info.AddValue("alt", alt);
        info.AddValue("den_alt", den_alt);
    }

    // The special constructor is used to deserialize values.
    public SerializableDataStruct(SerializationInfo info, StreamingContext context)
    {
        // Reset the property value using the GetValue method.
        myProperty_value = (string)info.GetValue("props", typeof(string));
    }

    public override string ToString()
    {
        //string value = date + " " + time;

        return "Date: " + this.date + ", Time: " + this.time + ", Magnetic Direction: " + this.mag_dir + ", True Direction: " + this.true_dir 
                + ", Wind Speed: " + this.wind_speed + ", Cross Wind: " + this.cross_wind + ", Head Wind: " + this.head_wind + ", Temperature: "
                + ", Wind Chill: " + this.wind_chill + ", Relative Humidity: " + this.rel_hum + ", Heat Index: " + this.heat_index + ", Dew Point: "
                + ", Wet Bulb: " + this.wet_bulb + ", Barometric Pressure: " + this.bar + ", Altitude: " + this.alt + ", Density Altitude: " + this.den_alt;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}