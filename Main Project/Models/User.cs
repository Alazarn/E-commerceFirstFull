using Microsoft.AspNetCore.Identity;

namespace E_commerceFirstFull.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
