using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.Reserves
{
    public class IndexModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public IndexModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reserve> Reserve { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reserve != null)
            {
                Reserve = await _context.Reserve.ToListAsync();
            }
        }
    }
}
