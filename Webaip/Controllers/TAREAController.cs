using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Webaip.Models;

namespace Webaip.Controllers
{
    public class TAREAController : ApiController
    {
        private PRUEBAEntities db = new PRUEBAEntities();

        // GET: api/TAREA
        public IQueryable<TAREA> GetTAREA()
        {
            return db.TAREA;
        }

        // GET: api/TAREA/5
        [ResponseType(typeof(TAREA))]
        [HttpGet]
        public IHttpActionResult GetTAREA(int id)
        {
            TAREA tAREA = db.TAREA.Find(id);
            if (tAREA == null)
            {
                return NotFound();
            }

            return Ok(tAREA);
        }

        // PUT: api/TAREA/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutTAREA(int id, TAREA tAREA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tAREA.ID_T)
            {
                return BadRequest();
            }

            var tar = db.SPA_UPDATETARE(tAREA.ID_T, tAREA.DESCRIPCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAREAExists(id))
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

        // POST: api/TAREA
        [ResponseType(typeof(TAREA))]
        [HttpPost]
        public IHttpActionResult PostTAREA(TAREA tAREA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tar = db.SPA_INSERTTAREA(tAREA.DESCRIPCION, tAREA.ID_P);

            return CreatedAtRoute("DefaultApi", new { id = tAREA.ID_T }, tAREA);
        }

        // DELETE: api/TAREA/5
        [ResponseType(typeof(TAREA))]
        [HttpDelete]
        public IHttpActionResult DeleteTAREA(int id)
        {
            TAREA tAREA = db.TAREA.Find(id);
            if (tAREA == null)
            {
                return NotFound();
            }

            var tar = db.SPA_DELETETAREA(id);

            return Ok(tAREA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TAREAExists(int id)
        {
            return db.TAREA.Count(e => e.ID_T == id) > 0;
        }
    }
}