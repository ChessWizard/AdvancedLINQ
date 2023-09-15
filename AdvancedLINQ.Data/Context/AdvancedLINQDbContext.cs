using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Entities.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.Context
{
    public class AdvancedLINQDbContext : DbContext
    {
        public AdvancedLINQDbContext(DbContextOptions<AdvancedLINQDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<CategoryMedia> CategoryMedias { get; set; }

        public DbSet<JobTask> Tasks { get; set; }

        public DbSet<Employee> Employees { get; set; }

        #region SaveChanges Interceptor

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            EnsureEntityType();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void EnsureEntityType()
        {
            var trackingEntities = ChangeTracker.Entries();

            foreach (var entity in trackingEntities)
            {
                if (entity.State is EntityState.Added && entity.Entity is IAuditEntity addedEntity)
                    addedEntity.CreatedDate = DateTimeOffset.UtcNow;

                if (entity.State is EntityState.Modified && entity.Entity is IAuditEntity modifiedEntity)
                    modifiedEntity.ModifiedDate = DateTimeOffset.UtcNow;
            }
        }

        #endregion
    }
}
