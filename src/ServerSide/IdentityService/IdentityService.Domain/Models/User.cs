using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Domain.Models
{
    public class User : IdentityUser
    {
        public string? GoogleId { get; set; }
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
