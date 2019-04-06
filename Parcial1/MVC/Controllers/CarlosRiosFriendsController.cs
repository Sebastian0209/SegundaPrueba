using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class CarlosRiosFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CarlosRiosFriends
        public ActionResult Index()
        {
            return View(db.CarlosRiosFriends.ToList());
        }

        // GET: CarlosRiosFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            if (carlosRiosFriend == null)
            {
                return HttpNotFound();
            }
            return View(carlosRiosFriend);
        }

        // GET: CarlosRiosFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarlosRiosFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Llave,NombreCompleto,TipoAmigo,Apodo,Cumpleaños")] CarlosRiosFriend carlosRiosFriend)
        {
            if (ModelState.IsValid)
            {
                db.CarlosRiosFriends.Add(carlosRiosFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carlosRiosFriend);
        }

        // GET: CarlosRiosFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            if (carlosRiosFriend == null)
            {
                return HttpNotFound();
            }
            return View(carlosRiosFriend);
        }

        // POST: CarlosRiosFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Llave,NombreCompleto,TipoAmigo,Apodo,Cumpleaños")] CarlosRiosFriend carlosRiosFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carlosRiosFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carlosRiosFriend);
        }

        // GET: CarlosRiosFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            if (carlosRiosFriend == null)
            {
                return HttpNotFound();
            }
            return View(carlosRiosFriend);
        }

        // POST: CarlosRiosFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            db.CarlosRiosFriends.Remove(carlosRiosFriend);
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
