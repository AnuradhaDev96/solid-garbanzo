using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BeginnerApp.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [DisplayName("Player Role")]
        public string PlayRole { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        // with default value
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
