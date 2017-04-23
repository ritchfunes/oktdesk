using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Models;
using PagedList;

namespace SmartAdminMvc.Controllers
{
    public class RecursoesController : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();

        // GET: Recursoes
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
         //   var recurso = db.Recurso.Include(r => r.Categoria).Include(r => r.Departamento);
            List<Recurso> listroles = db.Recurso.Include(r => r.Categoria).Include(r => r.Departamento).ToList();
            PagedList<Recurso> model = new PagedList<Recurso>(listroles, page, pagesize);
            return View(model);
          //  return View(recurso.ToList());
        }

        // GET: Recursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // GET: Recursoes/Create
        public ActionResult Create()
        {
            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre");
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre");
            return View();
        }

        // POST: Recursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_recurso,depto_id,categoria_id,nombre,marca,modelo,fec_adquisicion,activo")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Recurso.Add(recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.categoria_id);
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre", recurso.depto_id);
            return View(recurso);
        }

        // GET: Recursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.depto_id);
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre", recurso.depto_id);
            return View(recurso);
        }

        // POST: Recursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_recurso,depto_id,categoria_id,nombre,marca,modelo,fec_adquisicion,activo")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.depto_id);
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre", recurso.depto_id);
            return View(recurso);
        }

        // GET: Recursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recurso recurso = db.Recurso.Find(id);
            db.Recurso.Remove(recurso);
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
