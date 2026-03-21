using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.Patients
{
    public class UpdatePatientDTO
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
