using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebDiaryAPI.Models;

namespace WebDiaryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

    }
}
