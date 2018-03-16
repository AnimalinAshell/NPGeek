using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class SurveyModel
    {
        public string ParkCode { get; set; }
        [Required(ErrorMessage = "Invalid Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage= "Must Select A State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string ActivityLevel { get; set; }
        public int SurveyRank { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string ParkName { get; set; }
    }
}