

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NeMagazin.Models.EntityModels;
using NeMagazin.Models.ViewModels.Products;
using NeMagazin.Models.ViewModels.Users;

namespace NeMagazin.Services
{
    public class UserService : Service
    {
        public ProfileVM GetProfileVM(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            ProfileVM vm = Mapper.Map<ApplicationUser, ProfileVM>(user);

            List<Product> products = user.Products;

            vm.Products = Mapper.Map<List<Product>, IEnumerable<ProfileProductVM>>(products);

            return vm;
        }

        public EditProfileVM GetEditProfileVM(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditProfileVM vm = Mapper.Map<ApplicationUser, EditProfileVM>(user);
            

            return vm;
        }

        public void EditUser(EditProfileVM bind, string username)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            user.Name = bind.Name;

            this.Context.SaveChanges();
        }
    }
}
