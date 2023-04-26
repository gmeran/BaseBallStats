using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseBall_Stats.Models
{
    public class CreateHittingStatsModel
    {
        public int HittingStatId { get; set; }
        public int GamesPlayed { get; set; }
        public int PA { get; set; }
        public int Hits { get; set; }
        public int DB { get; set; }
        public int TRP { get; set; }
        public int HR { get; set; }
        public int SB { get; set; }
        public int CS { get; set; }
        public int BB { get; set; }
        public int SO { get; set; }
        public decimal BA { get; set; }
        public decimal OPB { get; set; }
        public decimal SLG { get; set; }
        public decimal OPS { get; set; }
        public int PlayerId { get; set; }
        public int StatYear { get; set; }
        public int AB { get; set; }
        public int R { get; set; }
        public int RBI { get; set; }
    }
       
}