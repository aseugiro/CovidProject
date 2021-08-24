using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{

    public class DataContainer<T>
    {

        /// <summary>
        /// Data
        /// </summary>
        [Column("data")]
        public List<T> Data { get; set; }






    }
}