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
    public class SerializableDataStruct : ISerializable
    {
        public DateTime date_time;
        public double time_seconds;
        public string mag_dir;
        public string true_dir;
        public double wind_speed;
        public double cross_wind;
        public double head_wind;
        public double temp;
        public double wind_chill;
        public double rel_hum;
        public double heat_index;
        public double dew_point;
        public double wet_bulb;
        public double bar;
        public double alt;
        public double den_alt;

        

        public SerializableDataStruct(DateTime in_date_time, int in_time_seconds, string in_mag_dir, string in_true_dir, double in_wind_speed, 
                                double in_cross_wind, double in_head_wind, double in_temp, double in_wind_chill, double in_rel_hum, 
                                double in_heat_index, double in_dew_point, double in_wet_bulb, double in_bar, double in_alt, double in_den_alt)
        {
            date_time = in_date_time;
            
            if (in_mag_dir != null)      
                mag_dir = in_mag_dir;      
            else      
                mag_dir = "NULL";

            time_seconds = in_time_seconds;

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

        public SerializableDataStruct() { }


        // The special constructor is used to deserialize values.
        public SerializableDataStruct(SerializationInfo info, StreamingContext context)
        {
            date_time = (DateTime)info.GetValue("date_time", typeof(DateTime));
            time_seconds = (double)info.GetValue("time_seconds", typeof(double));
            mag_dir = (string)info.GetValue("mag_dir", typeof(string));
            true_dir = (string)info.GetValue("true_dir", typeof(string));
            wind_speed = (double)info.GetValue("wind_speed", typeof(double));
            cross_wind = (double)info.GetValue("cross_wind", typeof(double));
            head_wind = (double)info.GetValue("head_wind", typeof(double));
            temp = (double)info.GetValue("temp", typeof(double));
            wind_chill = (double)info.GetValue("wind_chill", typeof(double));
            rel_hum = (double)info.GetValue("rel_hum", typeof(double));
            heat_index = (double)info.GetValue("heat_index", typeof(double));
            dew_point = (double)info.GetValue("dew_point", typeof(double));
            wet_bulb = (double)info.GetValue("wet_bulb", typeof(double));
            bar = (double)info.GetValue("bar", typeof(double));
            alt = (double)info.GetValue("alt", typeof(double));
            den_alt = (double)info.GetValue("den_alt", typeof(double));
        }

        // Implement this method to serialize data. The method is called 
        // on serialization.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("date_time", date_time);
            info.AddValue("time_seconds", time_seconds);
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

        

        public override string ToString()
        {
            //string value = date + " " + time;

            return "Date Time: " + this.date_time + ", Magnetic Direction: " + this.mag_dir + ", True Direction: " + this.true_dir 
                    + ", Wind Speed: " + this.wind_speed + ", Cross Wind: " + this.cross_wind + ", Head Wind: " + this.head_wind + ", Temperature: " + this.temp
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
}