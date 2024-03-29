﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ElearnerWebApp.Pages.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly ELearnerApi.Models.ElearnnerDBContext _context;

        public DetailsModel(ELearnerApi.Models.ElearnnerDBContext context)
        {
            _context = context;
        }

        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topics.FirstOrDefaultAsync(m => m.Id == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
