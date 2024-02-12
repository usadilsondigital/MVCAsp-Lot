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
    public class eventosController : Controller
    {
        private lotEntities db = new lotEntities();

        // GET: eventos
        public ActionResult Index()
        {
            return View(db.eventos.ToList());
        }

        // GET: eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body,start_time,finish_time,passed,created_at,updated_at")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,start_time,finish_time,passed,created_at,updated_at")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evento evento = db.eventos.Find(id);
            db.eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: listeve
        public ActionResult listeve()
        {
            return View(db.eventos.Where(x=>x.finish_time.CompareTo(DateTime.Now)<0).ToList());
        }

        // GET: definir
        public ActionResult definir()
        {
            return View(db.eventos.ToList());
        }

        // GET: define/5
        public ActionResult define(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
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
