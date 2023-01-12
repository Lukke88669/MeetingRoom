using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Meeting_Room.Data;
using Meeting_Room.Models;

namespace Meeting_Room.Pages.Reserves
{
    public class CreateModel : PageModel
    {
        private readonly Meeting_Room.Data.ApplicationDbContext _context;

        public SelectList? Ids { get; set; }

        public CreateModel(Meeting_Room.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // 第一步：從 MeetRoom 中，select 所有會議室的 Id
            var roomQuery = from m in _context.Room
                            select new { m.Id, m.Name };

            // var roomQuery = from m in _context.MeetRoom
            //                select m;

            /*
            https://www.learnrazorpages.com/razor-pages/forms/select-lists

            使用 SelectList 建立 Text 和 Value 的方式
            Options = new SelectList(context.Authors, nameof(Author.AuthorId), nameof(Author.Name));
            */

            Ids = new SelectList(roomQuery, "Id", "Name");

            // 多欄位與單一欄位的取值方式
            // Ids = new SelectList(await roomQuery.Select(x => x.Name).Distinct().ToListAsync());
            // Ids = new SelectList(await roomQuery.Distinct().ToListAsync());

            // 第二步：將 Id 列表，轉成 <select> 中的選項
            /*
                In Create.cshtml
                <select asp-for="Reserve.RoomId" asp-items="Model.Ids" class="form-control">
                </select>
             */

            return Page();
        }

        [BindProperty]
        public Reserve Reserve { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reserve.Add(Reserve);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
