using Microsoft.AspNetCore.Identity;

namespace AJST.Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}