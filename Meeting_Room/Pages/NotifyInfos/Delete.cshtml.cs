using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.NotifyInfos
{
    public class DeleteModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public DeleteModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NotifyInfo NotifyInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NotifyInfo == null)
            {
                return NotFound();
            }

            var notifyinfo = await _context.NotifyInfo.FirstOrDefaultAsync(m => m.Id == id);

            if (notifyinfo == null)
            {
                return NotFound();
            }
            else 
            {
                NotifyInfo = notifyinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NotifyInfo == null)
            {
                return NotFound();
            }
            var notifyinfo = await _context.NotifyInfo.FindAsync(id);

            if (notifyinfo != null)
            {
                NotifyInfo = notifyinfo;
                _context.NotifyInfo.Remove(NotifyInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
