using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAsp_Lot.Models;

namespace MVCAsp_Lot.Controllers
{
    public class tarjetasController : Controller
    {
        private lotEntities db = new lotEntities();

        // GET: tarjetas
        public ActionResult Index()
        {
            var tarjetas = db.tarjetas.Include(t => t.evento);
            return View(tarjetas.ToList());
        }

        // GET: tarjetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: tarjetas/Create
        public ActionResult Create()
        {
            ViewBag.evento_id = new SelectList(db.eventos, "id", "title");
            return View();
        }

        // POST: tarjetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,evento_id,user_id,body,estado,created_at,updated_at")] tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.tarjetas.Add(tarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.evento_id = new SelectList(db.eventos, "id", "title", tarjeta.evento_id);
            return View(tarjeta);
        }

        // GET: tarjetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.evento_id = new SelectList(db.eventos, "id", "title", tarjeta.evento_id);
            return View(tarjeta);
        }

        // POST: tarjetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,evento_id,user_id,body,estado,created_at,updated_at")] tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.evento_id = new SelectList(db.eventos, "id", "title", tarjeta.evento_id);
            return View(tarjeta);
        }

        // GET: tarjetas/definir/5
        public ActionResult definir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.evento_id = new SelectList(db.eventos, "id", "title", tarjeta.evento_id);
            return View(tarjeta);
        }

        // POST: tarjetas/definir/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult definir([Bind(Include = "id,evento_id,user_id,body,estado,created_at,updated_at")]tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.evento_id = new SelectList(db.eventos, "id", "title", tarjeta.evento_id);
            return View(tarjeta);
        }

        // GET: tarjetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta tarjeta = db.tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarjeta tarjeta = db.tarjetas.Find(id);
            db.tarjetas.Remove(tarjeta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
