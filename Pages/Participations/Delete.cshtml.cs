using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Participations
{
    public class DeleteModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public DeleteModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participation Participation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations.FirstOrDefaultAsync(m => m.ID == id);

            if (participation == null)
            {
                return NotFound();
            }
            else
            {
                Participation = participation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations.FindAsync(id);
            if (participation != null)
            {
                Participation = participation;
                _context.Participations.Remove(Participation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
