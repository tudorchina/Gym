﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gym.Pages.Memberships
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
        public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FirstOrDefaultAsync(m => m.ID == id);

            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                Membership = membership;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership != null)
            {
                Membership = membership;
                _context.Memberships.Remove(Membership);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
