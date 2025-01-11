using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gym.Pages.GymClasses
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public DeleteModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GymClass GymClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymclass = await _context.GymClasses.FirstOrDefaultAsync(m => m.ID == id);

            if (gymclass == null)
            {
                return NotFound();
            }
            else
            {
                GymClass = gymclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymclass = await _context.GymClasses.FindAsync(id);
            if (gymclass != null)
            {
                GymClass = gymclass;
                _context.GymClasses.Remove(GymClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
