using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.NotifyInfos
{
    public class CreateModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public CreateModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NotifyInfo NotifyInfo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NotifyInfo.Add(NotifyInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
