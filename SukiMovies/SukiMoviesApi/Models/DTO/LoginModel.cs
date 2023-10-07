using System.ComponentModel.DataAnnotations;

namespace SukiMoviesApi.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Passowrd { get; set; }
    }
}
