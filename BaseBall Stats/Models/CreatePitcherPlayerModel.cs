using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BaseBall_Stats.Models
{
    public class CreatePitcherPlayerModel
    {
        [Required]
        [Display(Name = "Player Id")]
        public int PlayerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Please Enter Either RHP,LHP,SP,orCP")]
        public string Postion { get; set; }
        [Required]
        public int YearStarted { get; set; }
        [Required]
        public int YearEnded { get; set; }
    }
}