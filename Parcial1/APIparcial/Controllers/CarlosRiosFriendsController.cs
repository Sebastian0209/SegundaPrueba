using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIparcial.Models;

namespace APIparcial.Controllers
{
    public class CarlosRiosFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CarlosRiosFriends
        public IQueryable<CarlosRiosFriend> GetCarlosRiosFriends()
        {
            return db.CarlosRiosFriends;
        }

        // GET: api/CarlosRiosFriends/5
        [ResponseType(typeof(CarlosRiosFriend))]
        public IHttpActionResult GetCarlosRiosFriend(int id)
        {
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            if (carlosRiosFriend == null)
            {
                return NotFound();
            }

            return Ok(carlosRiosFriend);
        }

        // PUT: api/CarlosRiosFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarlosRiosFriend(int id, CarlosRiosFriend carlosRiosFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carlosRiosFriend.Llave)
            {
                return BadRequest();
            }

            db.Entry(carlosRiosFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarlosRiosFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CarlosRiosFriends
        [ResponseType(typeof(CarlosRiosFriend))]
        public IHttpActionResult PostCarlosRiosFriend(CarlosRiosFriend carlosRiosFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarlosRiosFriends.Add(carlosRiosFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carlosRiosFriend.Llave }, carlosRiosFriend);
        }

        // DELETE: api/CarlosRiosFriends/5
        [ResponseType(typeof(CarlosRiosFriend))]
        public IHttpActionResult DeleteCarlosRiosFriend(int id)
        {
            CarlosRiosFriend carlosRiosFriend = db.CarlosRiosFriends.Find(id);
            if (carlosRiosFriend == null)
            {
                return NotFound();
            }

            db.CarlosRiosFriends.Remove(carlosRiosFriend);
            db.SaveChanges();

            return Ok(carlosRiosFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarlosRiosFriendExists(int id)
        {
            return db.CarlosRiosFriends.Count(e => e.Llave == id) > 0;
        }
    }
}