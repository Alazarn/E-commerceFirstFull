using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public CreateAndEditUserViewModel UserForm { get; set; }
    }
}
