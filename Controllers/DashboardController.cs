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
        private const string username = "_user";
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index(CategoryVM model)
        {
            var curentuser = User.Identity.Name.ToString();
            HttpContext.Session.SetString(username, curentuser);
            ViewBag.user = HttpContext.Session.GetString(username);
            model.Category = new TbCategories();
            model.Categories = _context.tbCategories.ToList();
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateNewTradeMark(CategoryVM model, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                model.Category.Image = file.FileName;
                _context.tbCategories.Add(model.Category);
                _context.SaveChanges();
                return RedirectToAction("Index", model);
            }
            return View("Index", model);

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
        [AutoValidateAntiforgeryToken]
        public IActionResult EditTradeMark(TbCategories model, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (model.Image == null)
                {
                    model.Image = file.FileName;
                }

                _context.tbCategories.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index", new CategoryVM() { });
            }
            return View(model);
        }

        public IActionResult Items()
        {
            ViewBag.user = HttpContext.Session.GetString(username);
            TempData["Cat"] = _context.tbCategories.ToList();
            var model = new ItemVM()
            {
                TbItems = _context.tbItems.ToList(),
                TbItem = new TbItems(),
                TbCategories = _context.tbCategories.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateNewItem(ItemVM model, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                model.TbItem.Image = file.FileName;
                _context.tbItems.Add(model.TbItem);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            return View("Items", model);
        }
        public IActionResult EditItem(int id)
        {
            ViewBag.catigories = _context.tbCategories.ToList();
            var oModel = _context.tbItems.Where(a => a.Id == id).FirstOrDefault();
            return View(oModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditItem(TbItems model, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (model.Image == null)
                {
                    model.Image = file.FileName;
                }

                _context.tbItems.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            ViewBag.catigories = _context.tbCategories.ToList();
            return View(model);
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
            ViewBag.user = HttpContext.Session.GetString(username);
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
            if (ModelState.IsValid)
            {

                _context.tbItemDetails.Add(model.ItemDetail);
                _context.SaveChanges();
                return RedirectToAction("ItemsDetail");
            }
            return View("ItemsDetail");
        }

        public IActionResult EditItemDetail(int id)
        {
            ViewBag.catigories = _context.tbCategories.ToList();
            ViewBag.items = _context.tbItems.ToList();
            var oModel = _context.tbItemDetails.Where(a => a.Id == id).FirstOrDefault();
            return View(oModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditItemDetail(TbItemDetails model)
        {
            if (ModelState.IsValid)
            {
                _context.tbItemDetails.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ItemsDetail");
            }
            ViewBag.catigories = _context.tbCategories.ToList();
            ViewBag.items = _context.tbItems.ToList();
            return View(model);
        }

        public IActionResult DeleteItemDetail(int id)
        {
            var oModel = _context.tbItemDetails.Where(a => a.Id == id).FirstOrDefault();
            oModel.Active = false;
            _context.tbItemDetails.Update(oModel);
            _context.SaveChanges();
            return RedirectToAction("ItemsDetail");
        }
    }
}
