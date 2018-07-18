using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public Context() : base("DBContext")
        {

        }

        public virtual DbSet<Note> Notes { get; set; }
    }
}
