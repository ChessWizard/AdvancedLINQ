using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.Repositories
{
    public class JobTaskRepository : IJobTaskRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public JobTaskRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public IQueryable<JobTask> GetAll()
        {
            return _context.Tasks
                .AsNoTracking();
        }
    }
}
