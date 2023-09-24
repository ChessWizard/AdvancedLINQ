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
    public class Artist : AuditEntity<Guid>, ISoftDeleteEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ArtistType ArtistType { get; set; }

        public bool IsDeleted { get; set; }

        // bir şarkıcı, birden fazla albüm çıkarabilir
        public ICollection<AlbumArtist> AlbumArtists { get; set; }

        // bir şarkıcının birden fazla single parçası olabilir
        public ICollection<Track> Tracks { get; set; }
    }
}
