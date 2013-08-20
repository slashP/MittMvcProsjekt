using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MittMvcProsjekt.Models;

namespace MittMvcProsjekt.Controllers
{
    public class KategoriController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Kategori/
        public ActionResult Index()
        {
            return View(db.Kategori.ToList());
        }

        //
        // GET: /Kategori/Details/5
        public ActionResult Details(Int32 id)
        {
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // GET: /Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kategori/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Kategori.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        //
        // GET: /Kategori/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Kategori/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        //
        // GET: /Kategori/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        //
        // POST: /Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Kategori kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
