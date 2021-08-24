using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{
    public class CityReport
    {

        [Column("name")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Column("confirmed")]
        [Display(Name = "confirmed")]
        public int Confirmed { get; set; }

        [Column("deaths")]
        [Display(Name = "deaths")]
        public int Deaths { get; set; }




        /// <summary>
        /// Constructor
        /// </summary>
        public CityReport() { }
    }
}