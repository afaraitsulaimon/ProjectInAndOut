using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            foreach (var obj in objList)
            {
                obj.ExpenseType =   _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }
            return View(objList);
            
        }

        //Get create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            ViewBag.TypeDropDown = TypeDropDown;
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


       


        //To get the Delete data and display it in a form
        // the id helps in getting the exact one we want to delete
       
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


        //To get the data we want to update and display it in a form
        // the id helps in getting the exact one we want to update

        public IActionResult Update(int? id)
        {
            //this to help with the display of the dropdown of the expense type

            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            ViewBag.TypeDropDown = TypeDropDown;

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);


        }


        //Updating our Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
