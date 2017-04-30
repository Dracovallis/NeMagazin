using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeMagazin.Models.EntityModels;
using NeMagazin.Models.ViewModels.Account;

namespace NeMagazin.Services
{
    public class AccountService : Service
    {
        public ApplicationUser GetNewUser(RegisterViewModel model)
        {
            var user = new ApplicationUser {
                UserName = model.Email,
                Email = model.Email,
                Name = this.GenerateNameFromEmail(model.Email)
            };

            return user;
        }

        private string GenerateNameFromEmail(string email)
        {
            return email.Split('@')[0];
        }
    }
}
