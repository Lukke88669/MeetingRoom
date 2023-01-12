using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.BorrowRecords
{
    public class DetailsModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public DetailsModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public BorrowRecord BorrowRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BorrowRecord == null)
            {
                return NotFound();
            }

            var borrowrecord = await _context.BorrowRecord.FirstOrDefaultAsync(m => m.Id == id);
            if (borrowrecord == null)
            {
                return NotFound();
            }
            else 
            {
                BorrowRecord = borrowrecord;
            }
            return Page();
        }
    }
}
