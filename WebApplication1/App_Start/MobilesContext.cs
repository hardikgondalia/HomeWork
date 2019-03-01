using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Start
{
    public class MobilesContext : DbContext
    {
        public DbSet<Mobile> productsproperty { get; set; }
    }
}