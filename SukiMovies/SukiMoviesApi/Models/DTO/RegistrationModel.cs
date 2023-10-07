using System.ComponentModel.DataAnnotations;

namespace SukiMoviesApi.Models.DTO
{
    public class RegistrationModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Passowrd { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
