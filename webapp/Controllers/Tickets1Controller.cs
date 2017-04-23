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
    public class Tickets1Controller : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();
        string conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [Authorize]
        // GET: Tickets1
        // tickets que crea el usuario con la etiqueta asignar 
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
            //    var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);
            //   return View(ticket.ToList());

            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
                 Where(c => c.estado_ticket == "Asignar" ).ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        // muestra los tickets asignados 
        public ActionResult Asignados(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c =>  c.estado_ticket == "Asignado").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        // muestra los tickets reasignados
        public ActionResult Reasignar(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.estado_ticket == "Reasignar").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        // muestra los tickets aceptados por el tecnico 
        public ActionResult Aceptar(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.estado_ticket == "Aceptar").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        // cuando el ticket pasa a ser verificado
        public ActionResult Verificar(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.estado_ticket == "Verificar").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        public ActionResult Calificar(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.estado_ticket == "Calificar").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        public ActionResult Calificado(int page = 1, int pagesize = 5)
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

            // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.estado_ticket == "Calificado").ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }

        [Authorize]
        // GET: Tickets1/Details/5
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        [Authorize]
        // GET: Tickets1/Create
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

            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre");
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre");
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre");
            return View();
        }

        [Authorize]
        // POST: Tickets1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)

       // public ActionResult Create([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_colaborador = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "4"), "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        // esta sirve para que el supervisor asigne al tecnico correspondiente 
        // GET: Tickets1/Edit/5
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "3"), "Id", "Email", ticket.encargado); // categoria 3 tecnico
            ViewBag.supervisor = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "2"), "Id", "Email", ticket.supervisor); // categoria 2 Supervisor
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        public ActionResult Cal(int? id)
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "3"), "Id", "Email", ticket.encargado); // categoria 3 tecnico
            ViewBag.supervisor = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "2"), "Id", "Email", ticket.supervisor); // categoria 2 Supervisor
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        public ActionResult Tecacep(int? id)
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "3"), "Id", "Email", ticket.encargado); // categoria 3 tecnico
            ViewBag.supervisor = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "2"), "Id", "Email", ticket.supervisor); // categoria 2 Supervisor
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        public ActionResult Cerrar(int? id)
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "3"), "Id", "Email", ticket.encargado); // categoria 3 tecnico
            ViewBag.supervisor = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "2"), "Id", "Email", ticket.supervisor); // categoria 2 Supervisor
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        public ActionResult Nota(int? id)
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "3"), "Id", "Email", ticket.encargado); // categoria 3 tecnico
            ViewBag.supervisor = new SelectList(db.AspNetUsers.Where(c => c.id_rol == "2"), "Id", "Email", ticket.supervisor); // categoria 2 Supervisor
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cal([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Verificar");
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        // POST: Tickets1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nota([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Calificar");
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tecacep([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Asignados");
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cerrar([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion,acti_encargado,acti_supervisor,aceptar,cerrado,verificar")] Ticket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Aceptar");
            }
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email", ticket.id_colaborador);
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }


        [Authorize]
        // GET: Tickets1/Delete/5
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
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Ticket.Find(id);
            db.Ticket.Remove(ticket);
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
