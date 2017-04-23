#region Using

using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
#endregion

namespace SmartAdminMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {



        string conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // GET: home/index
        [Authorize]
        public ActionResult Index()
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

                if(res3 == "1")
                {
                    // rol 1 es administrador 
                    ViewBag.Apellido = "este usuario posee un rol de administrador  ";
                }
                else if (res3 == "2")
                {
                    // rol 2 Supervisor 
                    ViewBag.Apellido = "este usuario posee un rol de supervisor  ";
                }
                else if(res3 == "3")
                {
                    // rol 3 Tecnico
                    ViewBag.Apellido = "este usuario posee un rol de tecnico ";
                }
                else
                {// rol 4 empleado
                    ViewBag.Apellido = "este usuario posee un rol de empleado ";
                }


            }
            catch (Exception )
            {
            }
            
            return View();
        }

        [Authorize]
        public ActionResult Social(FormCollection form)
        {
          
            string nombre = form["txtNombres"];
            string username = User.Identity.Name; 
            ViewBag.Nombre = nombre;
            int res = 0;
         //   string res2 = "";
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_rol", cnn);
                ;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID" , username /* nombre.ToString()*/);

              //  res = cmd.ExecuteNonQuery(); 
             //   res2 = cmd.ExecuteNonQuery().ToString();
             string    res3 = cmd.ExecuteScalar().ToString(); 
                cnn.Close();
             //   ViewBag.Res = res2;
                ViewBag.Resp = res3;
                if(res3 == "1")
                {
                    ViewBag.Apellido = "este usuario posee un rol de administrador";
                }

              /*  if (res >= 0)
                {
                    ViewBag.Apellido = "este usuario posee un rol ";
                }
                else
                {
                    ViewBag.Apellido = " no se pudo detectar el rol de dicho usuario";
                }
                */

            }
            catch (Exception)
            {
                //         throw new Exception("Error al eliminar el taxista", ex);
            }
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }
    }
}