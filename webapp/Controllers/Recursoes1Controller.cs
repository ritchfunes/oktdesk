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

using System.Data.SqlClient;
using System.Configuration;


namespace SmartAdminMvc.Controllers
{
    public class Recursoes1Controller : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();
        string conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [Authorize]
        // GET: Recursoes1
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

            //  var recurso = db.Recurso.Include(r => r.Categoria).Include(r => r.Departamento).Include(r => r.Categoria1);
            List<Recurso> listroles = db.Recurso.Include(r => r.Categoria).Include(r => r.Departamento).Include(r => r.Categoria1).ToList();
            PagedList<Recurso> model = new PagedList<Recurso>(listroles, page, pagesize);
            return View(model);
           // return View(recurso.ToList());
        }

        [Authorize]
        // GET: Recursoes1/Details/5
        public ActionResult Details(int? id)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

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

        [Authorize]
        // GET: Recursoes1/Create
        public ActionResult Create()
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre");
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre");
            ViewBag.categoria_id = new SelectList(db.Categoria, "id_categoria", "nombre");
            return View();
        }

        [Authorize]
        // POST: Recursoes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_recurso,depto_id,categoria_id,nombre,marca,modelo,fec_adquisicion,activo")] Recurso recurso)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }


            if (ModelState.IsValid)
            {
                db.Recurso.Add(recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.depto_id);
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre", recurso.depto_id);
            ViewBag.categoria_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.categoria_id);
            return View(recurso);
        }

        [Authorize]
        // GET: Recursoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

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
            ViewBag.categoria_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.categoria_id);
            return View(recurso);
        }

        [Authorize]
        // POST: Recursoes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_recurso,depto_id,categoria_id,nombre,marca,modelo,fec_adquisicion,activo")] Recurso recurso)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depto_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.depto_id);
            ViewBag.depto_id = new SelectList(db.Departamento, "id_depto", "nombre", recurso.depto_id);
            ViewBag.categoria_id = new SelectList(db.Categoria, "id_categoria", "nombre", recurso.categoria_id);
            return View(recurso);
        }

        [Authorize]
        // GET: Recursoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            string username = User.Identity.Name;
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", username /*nombre.ToString()*/);

                res = cmd.ExecuteNonQuery();
                string res3 = cmd.ExecuteScalar().ToString();
                cnn.Close();

                if (res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                    ViewBag.resultado = 1;

                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                    ViewBag.resultado = 2;
                }
                else if (res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                    ViewBag.resultado = 3;
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                    ViewBag.resultado = 4;
                }
            }
            catch (Exception)
            {
            }

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

        // POST: Recursoes1/Delete/5
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
