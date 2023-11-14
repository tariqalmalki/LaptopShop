using LaptopShop.Data;
using LaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaptopShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context= context;
        }

        public IActionResult Index(CategoryVM categoryVM)
        {
            var model = new CategoryVM() { };
            model.Category = new TbCategories();
            if (categoryVM.Categories == null)
            {
                model.Categories = _context.tbCategories.ToList();
            }
            else
            {
                model.Categories = categoryVM.Categories;
            }
            
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateNewCategory(TbCategories oTbCategories,IFormFile file)
        {
            oTbCategories.Image = file.FileName;
            _context.tbCategories.Add(oTbCategories);
            _context.SaveChanges();
            return View("Index", new CategoryVM() { });
        }
        public IActionResult Delete(int id)
        {
            var oModel = _context.tbCategories.Where(a=>a.Id == id).FirstOrDefault();
            oModel.Active = false;  
            _context.tbCategories.Update(oModel);
            _context.SaveChanges();
            return View("Index", new CategoryVM() { });
        }
        public IActionResult Edit(int id)
        {
            var oModel = _context.tbCategories.Where(a => a.Id == id).FirstOrDefault();
            return View(oModel);
        }
        [HttpPost]
        public IActionResult Edit(TbCategories model,IFormFile file)
        {
            model.Image = file.FileName;
            _context.tbCategories.Update(model);
            _context.SaveChanges();
            return View("Index",new CategoryVM() { });
        }
        public IActionResult Search(string category)
        {
            var oModel = new CategoryVM() {
                Categories = _context.tbCategories.Where(a => a.Name == category).ToList(),
            };
        return View("Index",oModel);
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