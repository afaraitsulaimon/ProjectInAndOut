using Microsoft.AspNetCore.Mvc;
using ProjectInAndOut.Data;
using ProjectInAndOut.Models;

namespace ProjectInAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //Get create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create, which means posting the form data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
