using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renato.ECommerce.Domain.DTOs;
using Renato.ECommerce.Domain.Services.Interfaces;
using Renato.ECommerce.WebUI.Models;

namespace Renato.ECommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = 
                productService ?? throw new ArgumentNullException("productService");
        }

        public IActionResult Index()
        {
            IEnumerable<DiscountedProduct> products =
                this.productService.GetFeaturedProducts();

            var vm = new FeaturedProductsViewModel(products.Select(e => new ProductViewModel(e)));

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
