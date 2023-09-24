using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Enums;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<Response<Unit>>
    {
        public List<Guid> ArtistIds { get; set; }

        public string Title { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public AlbumType AlbumType { get; set; }

        public string ImageUrl { get; set; }

        public List<CreateTrackModel> Tracks { get; set; }
    }

    public class CreateTrackModel
    {
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string TrackUrl { get; set; }

        public string ImageUrl { get; set; }
    }

    
}
