using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=aeroclub.db");
            }

            return new AeroclubDbContext(optionsBuilder.Options);
        }
    }
}
