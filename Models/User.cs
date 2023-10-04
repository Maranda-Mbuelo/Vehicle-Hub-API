using System.ComponentModel.DataAnnotations;

namespace Vehicle_Hub.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationTime { get; set; }

        // Define a collection navigation property for cars owned by this user
        public virtual ICollection<Car> Cars { get; set; }
    }
}
