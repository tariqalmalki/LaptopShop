using LaptopShop.Data;
using LaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopShop.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index(CategoryVM model)
        {
            model.Category = new TbCategories();
            model.Categories = _context.tbCategories.ToList();
            return View(model);
        }
        public IActionResult CreateNewTradeMark(CategoryVM model, IFormFile file)
        {
            model.Category.Image = file.FileName;
            _context.tbCategories.Add(model.Category);
            _context.SaveChanges();
            return RedirectToAction("Index", model);

        }
        
        public IActionResult DeleteTradeMark(int id)
        {
            var oModel = _context.tbCategories.Where(a => a.Id == id).FirstOrDefault();
            oModel.Active = false;
            _context.tbCategories.Update(oModel);
            _context.SaveChanges();
            return RedirectToAction("Index", new CategoryVM() { });
        }

        public IActionResult EditTradeMark(int id)
        {
            var oModel = _context.tbCategories.Where(a => a.Id == id).FirstOrDefault();
            return View(oModel);
        }
        [HttpPost]
        public IActionResult EditTradeMark(TbCategories model, IFormFile file)
        {
            if (model.Image == null)
            {
                model.Image = file.FileName;
            }

            _context.tbCategories.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index", new CategoryVM() { });
        }

        public IActionResult Items()
        {
            TempData["Cat"] = _context.tbCategories.ToList();
            var model = new ItemVM()
            {
                TbItems = _context.tbItems.ToList(),
                TbItem = new TbItems(),
                TbCategories = _context.tbCategories.ToList(),
            };
            return View(model);
        }
        public IActionResult CreateNewItem(ItemVM model, IFormFile file)
        {
            model.TbItem.Image = file.FileName;
            _context.tbItems.Add(model.TbItem);
            _context.SaveChanges();
            return RedirectToAction("Items");
        }
        public IActionResult EditItem(int id)
        {
            ViewBag.catigories = _context.tbCategories.ToList();
            var oModel = _context.tbItems.Where(a => a.Id == id).FirstOrDefault();
            return View(oModel);
        }
        [HttpPost]
        public IActionResult EditItem(TbItems model, IFormFile file)
        {
            if (model.Image == null)
            {
                model.Image = file.FileName;
            }

            _context.tbItems.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Items");
        }
        public IActionResult DeleteItem(int id)
        {
            var oModel = _context.tbItems.Where(a => a.Id == id).FirstOrDefault();
            oModel.Active = false;
            _context.tbItems.Update(oModel);
            _context.SaveChanges();
            return RedirectToAction("Items");
        }

        public IActionResult ItemsDetail()
        {
            
            var model = new ItemsDetailVM()
            {
                TbCategories = _context.tbCategories.ToList(),
                TbItems = _context.tbItems.ToList(),
                ItemDetail = new TbItemDetails(),
                ItemsDetails = _context.tbItemDetails.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateNewItemDetail(ItemsDetailVM model)
        {
            if(ModelState.IsValid)
            {

            _context.tbItemDetails.Add(model.ItemDetail);
            _context.SaveChanges();
            return RedirectToAction("ItemsDetail");
            }
            return View("ItemsDetail", model);
        }
    }
}
