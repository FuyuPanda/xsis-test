using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.Data.Entity
{
    public partial class XsisContext:DbContext
    {
        public XsisContext(DbContextOptions<XsisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
