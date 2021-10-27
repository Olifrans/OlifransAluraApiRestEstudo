using Microsoft.EntityFrameworkCore;
using OlifransAluraApiRestEstudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransAluraApiRestEstudo.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }

    }
}
