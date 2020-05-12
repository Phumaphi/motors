using System.ComponentModel.DataAnnotations;

namespace LagoMotors.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}