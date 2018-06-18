using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SigfazCore.Areas.Basico.Models;

namespace SigfazCore.Models
{
    public class SigfazCoreContext : DbContext
    {
        public SigfazCoreContext (DbContextOptions<SigfazCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }
}
