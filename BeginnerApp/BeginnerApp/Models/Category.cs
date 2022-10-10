using System;
using System.Collections.Generic;
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
        public int DisplayOrder { get; set; }

        // with default value
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
