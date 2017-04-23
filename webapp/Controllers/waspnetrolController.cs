using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartAdminMvc.Models;
using System.Threading.Tasks;

namespace SmartAdminMvc.Controllers
{
        

    public class waspnetrolController : ApiController
    {

        private SmartAdminMvcEntities1 db = new SmartAdminMvcEntities1(); 
        
        public IHttpActionResult Get()
        {
            var retval = db.AspNetRoles.ToList();
            return Ok(retval); 
        }

        public  async Task< IHttpActionResult> Post(String Name )
        {
            var rolestore = new RoleStore<IdentityRole>(db);
            var rolemanager = new RoleManager<IdentityRole>(rolestore) ;
            var result = await rolemanager.CreateAsync(new IdentityRole { Name = Name });
            return Ok(result); 

        }

        public async Task<IHttpActionResult> Delete(string Id)
        {
            var rolestore = new RoleStore<IdentityRole>(db);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);
            var role = await rolemanager.FindByIdAsync(Id);
            var result = await rolemanager.DeleteAsync(role);
            return Ok(result); 

        }

    }
}
