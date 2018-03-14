using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.DAL
{
    public interface IWeatherDAL
    {
        List<WeatherModel> GetWeather(string parkCode);
    }
}