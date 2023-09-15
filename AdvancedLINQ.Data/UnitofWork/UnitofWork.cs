using AdvancedLINQ.Core.UnitofWork;
using AdvancedLINQ.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AdvancedLINQDbContext _context;
        public UnitofWork(AdvancedLINQDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
                            => await _context.SaveChangesAsync();
        
    }
}
