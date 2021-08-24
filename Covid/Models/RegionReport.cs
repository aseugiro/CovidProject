using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Covid.Models
{
    public class RegionReport
    {

        [Column("iso")]
        [Display(Name = "Iso")]
        public String Iso { get; set; }

        [Column("name")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Column("province")]
        [Display(Name = "province")]
        public String Province { get; set; }

        [Column("cities")]
        public List<CityReport> Cities = null;


        /// <summary>
        /// Constructor
        /// </summary>
        public RegionReport() { }
    }
}