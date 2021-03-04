using System;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Models
{
    public class Gigg
    {

        public int Id { get; set; }

        [Required]
        public ApplicationUser Artist { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}