using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{
    public class CaseCovid
    {
        [Column("confirmed")]
        [Display(Name = "confirmed")]
        public int Confirmed { get; set; }

        [Column("deaths")]
        [Display(Name = "deaths")]
        public int Deaths { get; set; }

        [Column("confirmed_diff")]
        [Display(Name = "Confirmed Diff")]
        public int ConfirmedDiff { get; set; }


        [Column("deaths_diff")]
        [Display(Name = "Deaths Diff")]
        public int DeathsDiff { get; set; }

        [Column("recovered_diff")]
        [Display(Name = "Recovered Diff")]
        public int RecoveredDiff { get; set; }

        [Column("active")]
        [Display(Name = "active")]
        public int Active { get; set; }

        [Column("active_diff")]
        [Display(Name = "active_diff")]
        public int ActiveDiff { get; set; }

        [Column("last_update")]
        [Display(Name = "last_update")]
        public DateTime Last_Update { get; set; }

        [Column("region")]
        public RegionReport Region = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public CaseCovid() { }
    }
}