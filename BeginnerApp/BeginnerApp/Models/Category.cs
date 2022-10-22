using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Models
{
    public class Category
    {
        // type prop and it tab two times
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]        
        [Range(1, 100)] // Can specify an error message also
        public int DisplayOrder { get; set; }

        // with default value
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
