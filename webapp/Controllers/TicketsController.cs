using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Models;
using Microsoft.AspNet.Identity;
using PagedList;

using System.Web.Security;
using Microsoft.Ajax.Utilities;

using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartAdminMvc.Controllers
{
    public class TicketsController : Controller
    {
        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1();

        // GET: Tickets
        public ActionResult ConsultaTickets()
        {
            // Consultar tickets  
              var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);

            return View(ticket.ToList());
        }



        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            // tickets por asignar 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);
            //  string currentUserId = User.Identity.GetUserId();
           // var users =  await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //    string  current = User.Identity.GetUserId();
         //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
          //     Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
           //      Where(c => c.acti_encargado == false );
        //    Where(c => c.acti_encargado == false && c.AspNetUsers == );
          //  return View(ticket.ToList());


            List<Ticket> listroles = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
                 Where(c => c.acti_encargado == false).ToList();
            PagedList<Ticket> model = new PagedList<Ticket>(listroles, page, pagesize);
            return View(model);
        }
        
        public ActionResult Asignados()
        {
           // ticket asignados 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);

            var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.acti_encargado == true);
            return View(ticket.ToList());
        }

        public ActionResult Aceptotecnico()
        {
            // ticket  aceptdo por el tecnico
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);

            var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.acti_encargado == true && c.aceptar == true ); // agregar el usuario del tecnico logeado
            return View(ticket.ToList());
        }


        public ActionResult Resolucionticket()
        {
            // ticket ya fue resuelto de manera satisfactorio o no la solucion 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);
            
            var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.acti_encargado == true && c.aceptar == true && c.cerrado == true  ); // agregar lo que es condicion por usuario logeado
            return View(ticket.ToList());
        }

        public ActionResult Ticketcalificado()
        {
            // ticket ya fue resuelto de manera satisfactorio o no la solucion y calificado por el usuario 
            //   var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia);

            var ticket = db.Ticket.Include(t => t.AspNetUsers).Include(t => t.AspNetUsers1).
               Include(t => t.AspNetUsers2).Include(t => t.Calficacion).Include(t => t.Recurso).Include(t => t.Urgencia).
               Where(c => c.acti_encargado == true && c.aceptar == true && c.cerrado == true && c.acti_supervisor == true ); // 
            return View(ticket.ToList());
        }
        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id); 
      //  Ticket ticket2 = db.Ticket.f
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.id_colaborador = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre");
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre");
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
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

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
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
            ViewBag.encargado = new SelectList(db.AspNetUsers, "Id", "Email", ticket.encargado);
            ViewBag.supervisor = new SelectList(db.AspNetUsers, "Id", "Email", ticket.supervisor);
            ViewBag.id_calificacion = new SelectList(db.Calficacion, "id_calificacion", "nombre", ticket.id_calificacion);
            ViewBag.id_recurso = new SelectList(db.Recurso, "id_recurso", "nombre", ticket.id_recurso);
            ViewBag.id_urgencia = new SelectList(db.Urgencia, "id_prioridad", "nombre", ticket.id_urgencia);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ticket,id_colaborador,id_recurso,id_urgencia,descp_falla,fech_emision,fech_asignacion,fech_fin,estado_ticket,encargado,supervisor,comentario,obsevacion,id_calificacion,imagen,solucion")] Ticket ticket)
        {
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

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Tickets/Delete/5
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
