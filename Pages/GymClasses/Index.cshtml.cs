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
    public class IndexModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public IndexModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        public IList<GymClass> GymClass { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GymClass = await _context.GymClasses
                .Include(g => g.Trainer).ToListAsync();
        }
    }
}
