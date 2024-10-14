using BulkyWebBook.Data;
using BulkyWebBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BulkyWebDbContext _db;
        public CategoryController(BulkyWebDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
