using Microsoft.EntityFrameworkCore;
using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class ModelBase
    {

        protected readonly MyComercioContext _context;

        public ModelBase(IServiceProvider serviceProvider)
        {
            DbContextOptions<DbContext> options;
            var builder = new DbContextOptionsBuilder<DbContext>();
            builder.UseSqlServer(Guid.NewGuid().ToString());
            options = builder.Options;

            _context = new MyComercioContext(options);
        }
    }
}
