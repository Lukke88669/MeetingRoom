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
    public class IndexModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public IndexModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NotifyInfo> NotifyInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NotifyInfo != null)
            {
                NotifyInfo = await _context.NotifyInfo.ToListAsync();
            }
        }
    }
}
