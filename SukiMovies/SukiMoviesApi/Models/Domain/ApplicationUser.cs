using Microsoft.AspNetCore.Identity;

namespace SukiMoviesApi.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
