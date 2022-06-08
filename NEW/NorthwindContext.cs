using NEW.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW
{

    public class NorthwindContext : DbContext
    {
        public readonly static string conn_str = (@"Server = DESKTOP-EO459P4; Database=Northwind;User Id = ; Password=");

        public NorthwindContext() : base(conn_str)
        {

        }
        public readonly static SqlConnection Connection = new SqlConnection(@"Server = DESKTOP-EO459P4; Database=security;User Id = ; Password=;");



        // public readonly static string conn_str = (@"Server = DESKTOP-EO459P4; Database=Northwind;User Id = sa; Password=1");
        public virtual DbSet<Product> Products { get; set; }
        /* elimizdeki Products'ı veri tabanındaki products tablosuna direk baglıcak ve kullanmamıza yarıcak*/
        public DbSet<Category> Categories { get; set; }
    }
}
