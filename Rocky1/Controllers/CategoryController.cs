using Microsoft.AspNetCore.Mvc;
using Rocky1.Data;
using Rocky1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky1.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;  // это переменная в которую кладем информацию вытащенную из БД
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;                            // сразу в конструкторе ее инициализируем
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category; // вытаскиваем данные из БД
            return View(objList);                       // передаем данные во вьюшку
        }





        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        // GET - EDIT
        public IActionResult Edit(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj==null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        // GET - DELETE
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }















    }
}
