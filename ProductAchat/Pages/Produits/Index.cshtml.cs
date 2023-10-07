using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductAchat.Data;
using ProductAchat.Model;

namespace ProductAchat.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly ProductAchat.Data.ProductAchatContext _context;

        public IndexModel(ProductAchat.Data.ProductAchatContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string nomPrd { get; set; } = string.Empty;

        public IList<Produit> Produit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var produits = from m in _context.Produit select m;
            if (!String.IsNullOrEmpty(nomPrd))
            {
                produits = produits.Where(s => s.name.Contains(nomPrd));
            }
            Produit = await produits.ToListAsync();

            /* if (_context.Produit != null)
             {
                 Produit = await _context.Produit.ToListAsync();
             }*/
        }
    }
}
