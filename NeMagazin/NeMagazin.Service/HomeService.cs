using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeMagazin.Models.ViewModels.Home;

namespace NeMagazin.Services
{
    public class HomeService : Service
    {

        public string GetNameOfUser(string username)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            return user.Name;
        }

        public NavbarUserVM GetNavBarUserVM(string username)
        {
            string name = this.GetNameOfUser(username);

            NavbarUserVM vm = new NavbarUserVM
            {
                Name = name
            };

            return vm;
        }
    }
}
