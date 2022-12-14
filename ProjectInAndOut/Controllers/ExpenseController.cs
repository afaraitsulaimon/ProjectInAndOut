using Microsoft.AspNetCore.Mvc;
using ProjectInAndOut.Data;
using ProjectInAndOut.Models;

namespace ProjectInAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
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
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
        }


       


        //To get the Delete id
       
        public IActionResult Delete(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);

            if(obj == null)
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

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
