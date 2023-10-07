using System.ComponentModel.DataAnnotations;

namespace SukiMoviesApi.Models.DTO
{
    public class ChangePasswordModel
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set;}
        [Required]
        public string UserName { get; set; }


    }
}
