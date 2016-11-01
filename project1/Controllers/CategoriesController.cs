using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;

namespace project1.Controllers
{
    public class CategoriesController : Controller
    {
        private Sample db = new Sample();
        // GET: Categories
        public ActionResult Index (string searchstring)
        { 
            var catdal = from c in db.Categories
                         select c;
            if (!String.IsNullOrEmpty(searchstring))
            {
                catdal = catdal.Where(c => c.CategoryName.Contains(searchstring) || c.CategoryName.Contains(searchstring));
            }
            return View(catdal.ToList());
        }

// GET: Categories/Details/5
public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriesDAL cat = new CategoriesDAL();
                cat.Create(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)

        {
            //memanggil method delete
            CategoriesDAL categoriesDAL = new CategoriesDAL();
            var model = categoriesDAL.GetById(id);
            return View(model);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
