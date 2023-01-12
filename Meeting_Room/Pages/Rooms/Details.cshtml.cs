using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public DetailsModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
    }
}
