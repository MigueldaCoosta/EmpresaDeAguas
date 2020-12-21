using EmpresaDeAguas.web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeAguas.web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contador> Contadores { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
