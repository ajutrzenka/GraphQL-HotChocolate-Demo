using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AeroclubTimekeeper.Storage
{
    public class AeroclubDbContextFactory : IDesignTimeDbContextFactory<AeroclubDbContext>
    {
        public AeroclubDbContext CreateDbContext(string[] args)
        {
            return new AeroclubDbContext();
        }

        public static AeroclubDbContext CreateDbContext(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = AppDomain.CurrentDomain.BaseDirectory;
            dbPath = Path.Combine(dbPath, Consts.DatabaseName);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }

            return new AeroclubDbContext(optionsBuilder.Options);
        }
    }
}
