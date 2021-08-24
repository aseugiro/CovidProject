using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{
    public class ProvinceE
    {


        [Column("iso")]
        public String Iso { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("province")]
        public String Province { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProvinceE() { }
    }
}