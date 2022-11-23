using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeginnerApp.Models
{
    public class Trophy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Trophy Name")]
        public string TrophyName { get; set; }

        [DisplayName("Description")]
        public string TrophyDescription { get; set; }

        // with default value
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
