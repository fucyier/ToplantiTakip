using Microsoft.AspNet.Identity.EntityFramework;

namespace ToplantiTakip.Domain.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
