using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Galeria.Models.BindingModels;
using NeMagazin.Models.EntityModels;
using NeMagazin.Models.ViewModels.Products;
using NeMagazin.Models.ViewModels.Users;

namespace NeMagazin.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapping();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapping()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<ApplicationUser, ProfileVM>();
                expression.CreateMap<Product, ProfileProductVM>();
                expression.CreateMap<ApplicationUser ,EditProfileVM > ();
                expression.CreateMap<Product, AllProductsVM>();
                expression.CreateMap<CreateProductBM, Product>();
                expression.CreateMap<Product, EditProductVM>();
            });
        }
    }
}
