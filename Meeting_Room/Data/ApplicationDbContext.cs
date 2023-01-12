using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Meeting_Room.Models;

namespace Meeting_Room.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Meeting_Room.Models.BorrowRecord> BorrowRecord { get; set; }
        public DbSet<Meeting_Room.Models.NotifyInfo> NotifyInfo { get; set; }
        public DbSet<Meeting_Room.Models.Reserve> Reserve { get; set; }
        public DbSet<Meeting_Room.Models.Room> Room { get; set; }
     
    }
}