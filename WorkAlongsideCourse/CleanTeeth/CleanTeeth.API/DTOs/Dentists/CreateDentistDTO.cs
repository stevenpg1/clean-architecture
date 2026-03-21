using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.Dentists
{
    public class CreateDentistDTO
    {
        [Required]
        [StringLength(250)]
        public required string Name { get; set; }

        [Required]
        [StringLength(254)]
        public required string Email { get; set; }
    }
}
