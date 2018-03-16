﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string TempPicker { get; set; }

       
    }
}