using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NeMagazin.Models.ViewModels.Users;
using NeMagazin.Services;

namespace NeMagazin.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            this.service = new UserService();
        }
     
        // GET: Users
        public ActionResult Profile()
        {
            string username = User.Identity.Name;
            ProfileVM vm = this.service.GetProfileVM(username);

            return View(vm);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            string userName = User.Identity.Name;
            EditProfileVM vm = this.service.GetEditProfileVM(userName);

            return View(vm);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(EditProfileVM bind)
        {
            string username = User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                this.service.EditUser(bind, username);

                return this.RedirectToAction("Profile");
            }

            EditProfileVM vm = this.service.GetEditProfileVM(username);

            return this.View(vm);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
