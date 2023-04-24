using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseBall_Stats.Models
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int YearStated { get; set; }
        public int YearEnded { get; set; }
    }
}