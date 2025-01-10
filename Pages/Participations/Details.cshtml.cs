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
    public class DetailsModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public DetailsModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        public Participation Participation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations
                .Include(p => p.Member)
                .Include(p => p.GymClass)
                .FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
