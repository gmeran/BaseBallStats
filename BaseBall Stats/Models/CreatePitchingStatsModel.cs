using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseBall_Stats.Models
{
    public class CreatePitchingStatsModel
    {
        public int PitchingStatId { get; set; }
        public int statYear { get; set; }
        public int W { get; set; }
        public int L { get; set; }
        public decimal WLPECT { get; set; }
        public decimal ERA { get; set; }
        public decimal WHIP { get; set; }
        public int G { get; set; }
        public int GS { get; set; }
        public int CG { get; set; }
        public int SHO { get; set; }
        public int SV { get; set; }
        public decimal InningsPitched { get; set; }
        public int H { get; set; }
        public int R { get; set; }
        public int ER { get; set; }
        public int HR { get; set; }
        public int BB { get; set; }
        public int IBB { get; set; }
        public int SO { get; set; }
        public int HBP { get; set; }
        public int PlayerId { get; set; }
    }
}