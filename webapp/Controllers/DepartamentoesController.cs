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
    public class DepartamentoesController : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();
        string conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        [Authorize]
        // GET: Departamentoes
        public ActionResult Index(int page = 1, int pagesize = 5 )
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

            List<Departamento> listroles = db.Departamento.ToList();
            PagedList<Departamento> model = new PagedList<Departamento>(listroles, page, pagesize);
            return View(model);
           // return View(db.Departamento.ToList());
        }

        [Authorize]
        // GET: Departamentoes/Details/5
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
            Departamento departamento = db.Departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        [Authorize]
        // GET: Departamentoes/Create
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

            return View();
        }

        [Authorize]
        // POST: Departamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_depto,nombre,activo")] Departamento departamento)
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
                db.Departamento.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        [Authorize]
        // GET: Departamentoes/Edit/5
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
            Departamento departamento = db.Departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        [Authorize]
        // POST: Departamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_depto,nombre,activo")] Departamento departamento)
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
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        [Authorize]
        // GET: Departamentoes/Delete/5
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
            Departamento departamento = db.Departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamento.Find(id);
            db.Departamento.Remove(departamento);
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
