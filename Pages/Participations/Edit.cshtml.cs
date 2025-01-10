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

namespace Gym.Pages.Participations
{
    public class EditModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public EditModel(Gym.Data.GymContext context)
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

            var participation =  await _context.Participations.FirstOrDefaultAsync(m => m.ID == id);
            if (participation == null)
            {
                return NotFound();
            }
            Participation = participation;
           ViewData["GymClassID"] = new SelectList(_context.GymClasses, "ID", "Description");
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "Name");
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

            _context.Attach(Participation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipationExists(Participation.ID))
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

        private bool ParticipationExists(int id)
        {
            return _context.Participations.Any(e => e.ID == id);
        }
    }
}
