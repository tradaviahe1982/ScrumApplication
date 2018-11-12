using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace ScrumApplicationData
{
    public class ScrumApplicationDbFactory : IDesignTimeDbContextFactory<ScrumApplicationDbContext>
    {
        //
        public ScrumApplicationDbFactory()
        { }
        //
        public ScrumApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ScrumApplicationDbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=ScrumApplicationDbContext;Persist Security Info=True;User ID=sa;Password=123456;Pooling=true;Max Pool Size=500;Min Pool Size=5");
            return new ScrumApplicationDbContext(builder.Options);
        }
        //
    }
}
