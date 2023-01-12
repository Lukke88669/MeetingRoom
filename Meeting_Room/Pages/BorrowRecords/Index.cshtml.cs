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
    public class IndexModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public IndexModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BorrowRecord> BorrowRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BorrowRecord != null)
            {
                BorrowRecord = await _context.BorrowRecord.ToListAsync();
            }
        }
    }
}
