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
    public class AspNetUsersController : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();
        string conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // sirve para cambiar la clave por el usuario 
        public ActionResult formulario()
        {
            return View();
        }

        // sirve para reseta el password por el administrador 
        [Authorize]
        public  ActionResult restablecer()
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

        // sirve para reseta el password por el administrador 
        public ActionResult resetear(FormCollection form)
        {

         //   var apellido = form["txtApellido"];
            var nombre = form["txtNombre"];
            var nombres = form["txtNombres"];
            //  ViewBag.Apellido = apellido;
            ViewBag.Nombre = nombre;
            ViewBag.Nombres = nombres;

            //       Apellido: @ViewBag.Apellido
            // < br />
            //Nombre: @ViewBag.Nombre




            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_reset_password", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;


                  cmd.Parameters.AddWithValue("@email", nombre.ToString());
               // cmd.Parameters.AddWithValue("@pasword", apellido.ToString());

                res = cmd.ExecuteNonQuery();

                cnn.Close();
                if(res >= 1)
                {
                    ViewBag.Apellido = "se logro reiniciar password  exitosamente";
                    ViewBag.resultado = 1;
                }
                else
                {
                    ViewBag.Apellido = "no se pudo reiniciar su password exitosamente";
                    ViewBag.resultado = 0;
                }

            }
            catch (Exception)
            {
                //        throw new Exception("Error al actualizar el usuario", ex);
            }

    

            return View();
        }


        // sirve para cambiar la clave por el usuario 
        public ActionResult Guardar(FormCollection form)
        {
            var apellido = form["txtApellido"];
            var nombre = form["txtNombre"];
            ViewBag.Apellido = apellido;
            ViewBag.Nombre = nombre;

 //       Apellido: @ViewBag.Apellido
// < br />
 //Nombre: @ViewBag.Nombre




            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_upd_password", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@email", nombre.ToString());
                cmd.Parameters.AddWithValue("@pasword", apellido.ToString());

                res = cmd.ExecuteNonQuery();
                cnn.Close();
                if (res >= 1)
                {
                    ViewBag.Apellido = "se logro reiniciar password  exitosamente";
                    ViewBag.resultado = 1;
                }
                else
                {
                    ViewBag.Apellido = "no se pudo reiniciar su password exitosamente";
                    ViewBag.resultado = 0;
                }

            }
            catch (Exception )
            {
        //        throw new Exception("Error al actualizar el usuario", ex);
            }
           

        
            return View();
        }


        // GET: AspNetUsers
        [Authorize]
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

            List<AspNetUsers> listroles = db.AspNetUsers.ToList();
            PagedList<AspNetUsers> model = new PagedList<AspNetUsers>(listroles, page, pagesize);
            return View(model);

//            var aspNetUsers = db.AspNetUsers.Include(a => a.AspNetRoles1);
 //           return View(aspNetUsers.ToList());
        }

        [Authorize]
        // GET: AspNetUsers/Details/5
        public ActionResult Details(string id)
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
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

           
        // GET: AspNetUsers/Create
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
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name");
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Activo,cuenta,nombre,apellido,id_rol")] AspNetUsers aspNetUsers)
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
                db.AspNetUsers.Add(aspNetUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUsers.id_rol);
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
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
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUsers.id_rol);
            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Activo,cuenta,nombre,apellido,id_rol")] AspNetUsers aspNetUsers)
        {

            if (ModelState.IsValid)
            {
                db.Entry(aspNetUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUsers.id_rol);
            return View(aspNetUsers);
        }

        [Authorize]
        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(string id)
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
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUsers);
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
