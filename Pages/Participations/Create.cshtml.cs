using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Data;
using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Pages.Participations
{
    public class CreateModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public CreateModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GymClassID"] = new SelectList(_context.GymClasses, "ID", "Description");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Participation Participation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MemberID"] = new SelectList(_context.Member, "ID", "Name");
                ViewData["GymClassID"] = new SelectList(_context.GymClasses, "ID", "Description");
                return Page();
                
            }
            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == Participation.MemberID);
            var gymClass = await _context.GymClasses.FirstOrDefaultAsync(c => c.ID == Participation.GymClassID);

            if (gymClass.IsPremium && member.Membership != "Premium")
            {
                // Adăugăm un mesaj de eroare
                ModelState.AddModelError(string.Empty, "You must have a Premium membership to join this class.");

                // Repopulăm dropdown-urile și reîncărcăm pagina
                ViewData["MemberID"] = new SelectList(_context.Member, "ID", "Name");
                ViewData["GymClassID"] = new SelectList(_context.GymClasses, "ID", "Description");
                return Page();
            }

            _context.Participations.Add(Participation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
