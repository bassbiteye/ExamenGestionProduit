using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGestionProduit.Models
{
    public class ExamenContext : DbContext
    {
        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        { }

        public DbSet<Produit> produits { get; set; }
    }
}