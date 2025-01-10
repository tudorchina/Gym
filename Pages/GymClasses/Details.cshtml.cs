using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.GymClasses
{
    public class DetailsModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public DetailsModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

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
    }
}
