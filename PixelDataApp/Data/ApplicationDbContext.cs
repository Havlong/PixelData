using Microsoft.EntityFrameworkCore;
using PixelDataApp.Models;

namespace PixelDataApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelGroup> LabelGroups { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }
}