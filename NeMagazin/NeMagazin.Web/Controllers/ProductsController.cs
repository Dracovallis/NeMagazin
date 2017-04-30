using System.Collections.Generic;
using System.Web.Mvc;
using Galeria.Models.BindingModels;
using Galeria.Models.ViewModels.Products;
using NeMagazin.Models.ViewModels.Products;
using NeMagazin.Services;

namespace NeMagazin.Web.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private ProductsService service;

        public ProductsController()
        {
            this.service = new ProductsService();
        }

        // GET: Products
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            IEnumerable<AllProductsVM> vm = this.service.GetAllProducts();

            return View(vm);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        [HttpGet, Route("create")]
        [Authorize]
        public ActionResult Create()
        {
            CreateProductVM vm = new CreateProductVM();

            return View(vm);
        }

        // POST: Products/Create
        [HttpPost, Route("create")]
        [Authorize]
        public ActionResult Create(CreateProductBM cpbm)
        {
            if (this.ModelState.IsValid)
            {
                string username = User.Identity.Name;
                this.service.CreateNewProduct(cpbm, username);

                return this.RedirectToAction("Index");
            }

            CreateProductVM vm = new CreateProductVM();

            return View(vm);

        }

        // GET: Products/Edit/5
        [HttpGet, Route("edit/{id}")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            string username = User.Identity.Name;

            if (this.service.ProductBelongsToUser(username, id))
            {
                EditProductVM vm = this.service.GetEditProductVM(id);

                return View(vm);
            }

            return RedirectToAction("index", "home");
        }

        // POST: Products/Edit/5
        [HttpPost, Route("edit")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
