using AdvancedLINQ.Core.Entities.Common;
using AdvancedLINQ.Core.Entities.Common.Interfaces;
using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class Album : AuditEntity<Guid>, ISoftDeleteEntity
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public AlbumType AlbumType { get; set; }// Albüm, Single ayrımı

        // bir albüme, single'a sahip olan birden fazla şarkıcı, grup olabilir
        public ICollection<AlbumArtist> AlbumArtists { get; set; }

        // bir albümde birden fazla parça bulunabilir
        public ICollection<Track> Tracks { get; set; }
    }
}
