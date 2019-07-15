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
using WebAPI.DataBase;

namespace WebAPI.Controllers
{
    public class UserInfoesController : ApiController
    {
        private WebAPIDB db = new WebAPIDB();

        // GET: api/UserInfoes
        public IQueryable<UserInfo> GetUserInfos()
        {
            return db.UserInfos;
        }

        // GET: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> GetUserInfo(int id)
        {
            UserInfo userInfo = await db.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/UserInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.InfoUserID)
            {
                return BadRequest();
            }

            db.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/UserInfoes
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> PostUserInfo(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserInfos.Add(userInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userInfo.InfoUserID }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> DeleteUserInfo(int id)
        {
            UserInfo userInfo = await db.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            db.UserInfos.Remove(userInfo);
            await db.SaveChangesAsync();

            return Ok(userInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoExists(int id)
        {
            return db.UserInfos.Count(e => e.InfoUserID == id) > 0;
        }
    }
}