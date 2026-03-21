using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.Dentists
{
    public class UpdateDentistDTO
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(254)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
