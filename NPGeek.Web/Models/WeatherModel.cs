using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int Low { get; private set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string TempPicker { get; set; } = "far";

        //public void SetValue()
        //{
        //    if(tempType == "Fahrenheit")
        //    {
        //        this.High = High;
        //        this.Low = Low;
        //    }
        //    else if(tempType == "Celsius")
        //    {
        //        this.High = (High - 32) * 5 / 9;
        //        this.Low = (Low - 32) * 5 / 9;
        //    }
        //}
    }
}