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
    public class TidsskriftController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Tidsskrift/
        public ActionResult Index()
        {
            var tidsskrift = db.Tidsskrift.Include(t => t.Kategori);
            return View(tidsskrift.ToList());
        }

        //
        // GET: /Tidsskrift/Details/5
        public ActionResult Details(Int32 id)
        {
            Tidsskrift tidsskrift = db.Tidsskrift.Find(id);
            if (tidsskrift == null)
            {
                return HttpNotFound();
            }
            return View(tidsskrift);
        }

        //
        // GET: /Tidsskrift/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "Type");
            return View();
        }

        //
        // POST: /Tidsskrift/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tidsskrift tidsskrift)
        {
            if (ModelState.IsValid)
            {
                db.Tidsskrift.Add(tidsskrift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "Type", tidsskrift.KategoriId);
            return View(tidsskrift);
        }

        //
        // GET: /Tidsskrift/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Tidsskrift tidsskrift = db.Tidsskrift.Find(id);
            if (tidsskrift == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "Type", tidsskrift.KategoriId);
            return View(tidsskrift);
        }

        //
        // POST: /Tidsskrift/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tidsskrift tidsskrift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tidsskrift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategori, "Id", "Type", tidsskrift.KategoriId);
            return View(tidsskrift);
        }

        //
        // GET: /Tidsskrift/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Tidsskrift tidsskrift = db.Tidsskrift.Find(id);
            if (tidsskrift == null)
            {
                return HttpNotFound();
            }
            return View(tidsskrift);
        }

        //
        // POST: /Tidsskrift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Tidsskrift tidsskrift = db.Tidsskrift.Find(id);
            db.Tidsskrift.Remove(tidsskrift);
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
