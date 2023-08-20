using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nauka.test.impl.Models
{
    public class NaukaDbContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<User> Users { get; set; }

        public NaukaDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Join(Environment.GetFolderPath(folder), "NAUKA");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DbPath = Path.Join(path, "nauka.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
