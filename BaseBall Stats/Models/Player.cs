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
    
    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            this.Hitting_Stats = new HashSet<Hitting_Stats>();
            this.Pitching_Stats = new HashSet<Pitching_Stats>();
        }
    
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postion { get; set; }
        public Nullable<int> YearStarted { get; set; }
        public Nullable<int> YearEnded { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hitting_Stats> Hitting_Stats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pitching_Stats> Pitching_Stats { get; set; }
    }
}
