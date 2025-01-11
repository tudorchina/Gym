using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gym.Pages.GymClasses
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public EditModel(Gym.Data.GymContext context)
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

            var gymclass =  await _context.GymClasses.FirstOrDefaultAsync(m => m.ID == id);
            if (gymclass == null)
            {
                return NotFound();
            }
            GymClass = gymclass;
           ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GymClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymClassExists(GymClass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GymClassExists(int id)
        {
            return _context.GymClasses.Any(e => e.ID == id);
        }
    }
}
