using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI3.Models;

namespace WebAPI3.Controllers
{
    public class CardsController : ApiController
    {
        private WebAPI3Context db = new WebAPI3Context();

        // GET: api/Cards
        public IQueryable<Cards> GetCards()
        {
            return db.Cards;
        }

        // GET: api/Cards/5
        [ResponseType(typeof(Cards))]
        public async Task<IHttpActionResult> GetCards(int id)
        {
            Cards cards = await db.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }

            return Ok(cards);
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCards(int id, Cards cards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cards.Id)
            {
                return BadRequest();
            }

            db.Entry(cards).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardsExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(Cards))]
        public async Task<IHttpActionResult> PostCards(Cards cards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cards.Add(cards);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cards.Id }, cards);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Cards))]
        public async Task<IHttpActionResult> DeleteCards(int id)
        {
            Cards cards = await db.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }

            db.Cards.Remove(cards);
            await db.SaveChangesAsync();

            return Ok(cards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardsExists(int id)
        {
            return db.Cards.Count(e => e.Id == id) > 0;
        }
    }
}