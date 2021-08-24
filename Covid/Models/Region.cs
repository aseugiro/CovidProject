using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{
    public class Region
    {

        [Column("iso")]
        [Display(Name = "ISO")]
        public String Iso { get; set; }

        [Column("name")]
        [Display(Name = "name")]
        public String Name { get; set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public Region() { }
    }
}