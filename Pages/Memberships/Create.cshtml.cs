﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Data;
using Gym.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gym.Pages.Memberships
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Gym.Data.GymContext _context;

        public CreateModel(Gym.Data.GymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Memberships.Add(Membership);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
