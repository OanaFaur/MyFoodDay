using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFoodDay.Data;
using MyFoodDay.Models;
using MyFoodDayWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFoodDayWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly INutrientIntakeRepository intakeRepository;
        private readonly IAccountRepository accountReposotiry;
        private readonly UserManager<IdentityUser> userManager;

        public ProductController(
            IProductRepository productRepository,
            INutrientIntakeRepository intakeRepository,
            IAccountRepository accountRepository,
            UserManager<IdentityUser> userManager
            )
        {
            this.productRepository = productRepository;
            this.intakeRepository = intakeRepository;
            this.accountReposotiry = accountRepository;
            this.userManager = userManager;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ShowProducts()
        {
            List<Product> products = productRepository.GetProducts;

            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.AddProduct(product);
            return View();
        }

        public async Task<IActionResult> AddConsumedProduct(string name)
        {
            Product product = productRepository.FindByName(name);

            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            IdentityUser currentUser = await userManager.FindByEmailAsync(userEmail);

            EatenProduct consumedProduct = new()
            {
                ProductName = product.ProductName,
                Date = DateTime.Today,
                CaloriesConsumed = CountCalories(product.ProductName, product.Quantity),
                ProteinsConsumed = CountProteins(product.ProductName, product.Quantity),
                FatsConsumed = CountFats(product.ProductName, product.Quantity),
                UserId = currentUser.Id
            };

            intakeRepository.AddConsumedProduct(consumedProduct);

            return RedirectToAction("DailyIntake");
        }

        [HttpGet]
        public async Task<IActionResult> DailyIntake(DateTime? dateTime)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            IdentityUser currentUser = await userManager.FindByEmailAsync(userEmail);

            DateTime selectedDate = dateTime.HasValue ? dateTime.Value : DateTime.Today;

            DailyIntake viewIntake = new DailyIntake
            {
                CalorieNumber = CalculateCalories(selectedDate, currentUser.Id),
                ProteinNumber = CalculateProteins(selectedDate, currentUser.Id),
                Fats = CalculateFats(selectedDate, currentUser.Id),
                DateTime = dateTime,
            };

            return View("DailyIntake", viewIntake);
        }

        [HttpPost]
        public async Task<IActionResult> DailyIntake(DateTime dateTime)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            IdentityUser currentUser = await userManager.FindByEmailAsync(userEmail);

            DailyIntake viewIntake = new DailyIntake
            {
                CalorieNumber = CalculateCalories(dateTime, currentUser.Id),
                ProteinNumber = CalculateProteins(dateTime, currentUser.Id),
                Fats = CalculateFats(dateTime, currentUser.Id),
                DateTime = dateTime,
            };

            return View("DailyIntake", viewIntake);
        }

        private double CountCalories(string name, double quantityConsumed)
        {
            Product product = productRepository.FindByName(name);

            return quantityConsumed * product.Calories / product.Quantity;
        }

        private double CountProteins(string name, double quantityConsumed)
        {
            Product product = productRepository.FindByName(name);

            return quantityConsumed * product.Proteins / product.Quantity;
        }

        private double CountFats(string name, double quantityConsumed)
        {
            Product product = productRepository.FindByName(name);

            return quantityConsumed * product.Fats / product.Quantity;
        }

        private double CalculateCalories(DateTime DateTime, string email)
        {
            double totalCalories = intakeRepository
                .GetDailyConsumedProducts(DateTime, email)
                .Sum(x => x.CaloriesConsumed);

            return totalCalories;
        }

        private double CalculateProteins(DateTime dateTime, string email)
        {
            double totalProteins = intakeRepository
                .GetDailyConsumedProducts(dateTime, email)
                .Sum(x => x.ProteinsConsumed);

            return totalProteins;
        }

        private double CalculateFats(DateTime dateTime, string email)
        {
            double totalFats = intakeRepository
                .GetDailyConsumedProducts(dateTime, email)
                .Sum(x => x.FatsConsumed);

            return totalFats;
        }
    }
}
