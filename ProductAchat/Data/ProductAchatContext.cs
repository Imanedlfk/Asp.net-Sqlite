using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAchat.Model;

namespace ProductAchat.Data
{
    public class ProductAchatContext : DbContext
    {
        public ProductAchatContext (DbContextOptions<ProductAchatContext> options)
            : base(options)
        {
        }

        public DbSet<ProductAchat.Model.Produit> Produit { get; set; } = default!;
    }
}
