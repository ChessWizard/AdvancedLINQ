using AdvancedLINQ.Core.Entities.Common;
using AdvancedLINQ.Core.Entities.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class Track : AuditEntity<Guid>, ISoftDeleteEntity
    {
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public int PlayCount { get; set; }

        public DateTimeOffset PlayDate { get; set; }

        public string TrackUrl { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public Guid AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
