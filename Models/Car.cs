using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Hub.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Make { get; set; }

        [Required]
        [MaxLength(255)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string PlateNumber { get; set; }

        [Required]
        public DateTime RegistrationTime { get; set; }

        [Required]
        public DateTime CollectionTime { get; set; }

        // Define a foreign key property for the owner (UserId)
        public int OwnerId { get; set; }

        // Define a navigation property to represent the owner
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
