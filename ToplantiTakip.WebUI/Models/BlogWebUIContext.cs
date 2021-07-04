using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToplantiTakip.WebUI.Models
{
    public class ToplantiTakipWebUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ToplantiTakipWebUIContext() : base("name=ToplantiTakipWebUIContext")
        {
        }

        public System.Data.Entity.DbSet<ToplantiTakip.Domain.Concrete.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<ToplantiTakip.Domain.Concrete.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<ToplantiTakip.Domain.Concrete.Event> Events { get; set; }

    }
}
