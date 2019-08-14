using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Webaip.Models;

namespace Webaip.Controllers
{
    public class PERSONAController : ApiController
    {
        private PRUEBAEntities db = new PRUEBAEntities();

        // GET: api/PERSONA
        public IQueryable<PERSONA> GetPERSONA()
        {
            return db.PERSONA;
        }

        // GET: api/PERSONA/5
        [ResponseType(typeof(PERSONA))]
        [HttpGet]
        public IHttpActionResult GetPERSONA(int id)
        {
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                return NotFound();
            }

            return Ok(pERSONA);
        }

        // PUT: api/PERSONA/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutPERSONA(int id, PERSONA pERSONA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSONA.ID_P)
            {
                return BadRequest();
            }

            var per = db.SPA_UPDATEPERSONA(pERSONA.ID_P, pERSONA.NOMBRE, pERSONA.APELLIDO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSONAExists(id))
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

        // POST: api/PERSONA
        [ResponseType(typeof(PERSONA))]
        [HttpPost]
        public IHttpActionResult PostPERSONA(PERSONA pERSONA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perid = db.SPA_INSERTPERSONA(pERSONA.NOMBRE, pERSONA.APELLIDO);

            return CreatedAtRoute("DefaultApi", new { id = pERSONA.ID_P }, pERSONA);
        }

        // DELETE: api/PERSONA/5
        [ResponseType(typeof(PERSONA))]
        [HttpDelete]
        public IHttpActionResult DeletePERSONA(int id)
        {
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                return NotFound();
            }

            var per = db.SPA_DELETEPERSONA(id);

            //db.PERSONA.Remove(pERSONA);
            //db.SaveChanges();

            return Ok(pERSONA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSONAExists(int id)
        {
            return db.PERSONA.Count(e => e.ID_P == id) > 0;
        }
    }
}