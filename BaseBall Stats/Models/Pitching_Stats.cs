//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseBall_Stats.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pitching_Stats
    {
        public int PitchingStatId { get; set; }
        public Nullable<int> statYear { get; set; }
        public Nullable<int> W { get; set; }
        public Nullable<int> L { get; set; }
        public Nullable<decimal> WLPECT { get; set; }
        public Nullable<decimal> ERA { get; set; }
        public Nullable<decimal> WHIP { get; set; }
        public Nullable<int> G { get; set; }
        public Nullable<int> GS { get; set; }
        public Nullable<int> CG { get; set; }
        public Nullable<int> SHO { get; set; }
        public Nullable<int> SV { get; set; }
        public Nullable<decimal> InningsPitched { get; set; }
        public Nullable<int> H { get; set; }
        public Nullable<int> R { get; set; }
        public Nullable<int> ER { get; set; }
        public Nullable<int> HR { get; set; }
        public Nullable<int> BB { get; set; }
        public Nullable<int> IBB { get; set; }
        public Nullable<int> SO { get; set; }
        public Nullable<int> HBP { get; set; }
        public int PlayerId { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
