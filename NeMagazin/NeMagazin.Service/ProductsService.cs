using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Galeria.Models.BindingModels;
using NeMagazin.Models.EntityModels;
using NeMagazin.Models.ViewModels.Products;

namespace NeMagazin.Services
{
    public class ProductsService : Service
    {
        public IEnumerable<AllProductsVM> GetAllProducts()
        {
            IEnumerable<AllProductsVM> vm = this.Context.Products.ToList().Select(product => Mapper.Map<Product, AllProductsVM>(product)).ToList();

            return vm;
            
        }

        public void CreateNewProduct(CreateProductBM cpbm, string username)
        {
            Product product = Mapper.Map<CreateProductBM, Product>(cpbm);
            ApplicationUser poster = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            product.User = poster;
            poster.Products.Add(product);          

            this.Context.SaveChanges();
        }

        public bool ProductBelongsToUser(string username, int id)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user.Products.Any(x => x.Id == id))
            {
                return true;
            }

            return false;
        }

        public EditProductVM GetEditProductVM(int id)
        {
            Product product = this.Context.Products.FirstOrDefault(u => u.Id == id);

            EditProductVM vm = Mapper.Map<Product, EditProductVM>(product);

            return vm;
        }
    }
}
