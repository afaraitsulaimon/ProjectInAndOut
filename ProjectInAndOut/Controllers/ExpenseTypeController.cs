using Microsoft.AspNetCore.Mvc;
using ProjectInAndOut.Data;
using ProjectInAndOut.Models;

namespace ProjectInAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
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
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }





        //To get the Delete data and display it in a form
        // the id helps in getting the exact one we want to delete

        public IActionResult Delete(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);


        }


        //Post Delete an item, which means removing from database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


        //To get the data we want to update and display it in a form
        // the id helps in getting the exact one we want to update

        public IActionResult Update(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);


        }


        //Updating our Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
