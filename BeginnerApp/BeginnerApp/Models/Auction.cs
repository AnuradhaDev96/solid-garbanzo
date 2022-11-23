using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeginnerApp.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Actual Amount")]
        public int ActualAmount { get; set; }

        public int Status { get; set; }

        [Required]
        [DisplayName("End Time")]
        public string EndTime { get; set; }

        [Required]
        [DisplayName("Start Time")]
        public string StartTime { get; set; }

        // with default value
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
