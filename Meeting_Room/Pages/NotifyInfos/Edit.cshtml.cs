using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.NotifyInfos
{
    public class EditModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public EditModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NotifyInfo NotifyInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NotifyInfo == null)
            {
                return NotFound();
            }

            var notifyinfo =  await _context.NotifyInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (notifyinfo == null)
            {
                return NotFound();
            }
            NotifyInfo = notifyinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NotifyInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotifyInfoExists(NotifyInfo.Id))
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

        private bool NotifyInfoExists(int id)
        {
          return _context.NotifyInfo.Any(e => e.Id == id);
        }
    }
}
