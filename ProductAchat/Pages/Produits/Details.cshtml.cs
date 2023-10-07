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
    public class DetailsModel : PageModel
    {
        private readonly ProductAchat.Data.ProductAchatContext _context;

        public DetailsModel(ProductAchat.Data.ProductAchatContext context)
        {
            _context = context;
        }

      public Produit Produit { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FirstOrDefaultAsync(m => m.id == id);
            if (produit == null)
            {
                return NotFound();
            }
            else 
            {
                Produit = produit;
            }
            return Page();
        }
    }
}
