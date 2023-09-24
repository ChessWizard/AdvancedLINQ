using AdvancedLINQ.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class AlbumArtist : BaseEntity<Guid>
    {
        public Guid AlbumId { get; set; }

        public Album Album { get; set; }

        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}
