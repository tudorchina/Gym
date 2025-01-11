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

namespace Gym.Pages.Trainers
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
        public Trainer Trainer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.FirstOrDefaultAsync(m => m.ID == id);

            if (trainer == null)
            {
                return NotFound();
            }
            else
            {
                Trainer = trainer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer != null)
            {
                Trainer = trainer;
                _context.Trainer.Remove(Trainer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
