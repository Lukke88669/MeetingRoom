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
    public class DetailsModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public DetailsModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Reserve Reserve { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserve.FirstOrDefaultAsync(m => m.Id == id);
            if (reserve == null)
            {
                return NotFound();
            }
            else 
            {
                Reserve = reserve;
            }
            return Page();
        }
    }
}
