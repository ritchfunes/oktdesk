using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Models
{
    public class Role
    {

       
        public int RoleId { get; set; }
        public string roledescription { get; set; }
        public bool issyssadmin { get; set; }

    }
}