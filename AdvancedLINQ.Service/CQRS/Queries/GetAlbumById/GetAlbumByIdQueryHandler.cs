using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Shared.Extensions;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, Response<GetAlbumByIdQueryResult>>
    {
        private readonly IAlbumRepository _albumRepository;

        public GetAlbumByIdQueryHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Response<GetAlbumByIdQueryResult>> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _albumRepository.GetAll()
                .Include(x => x.Tracks)
                .Include(x => x.AlbumArtists)
                    .ThenInclude(y => y.Artist)
                .Where(x => x.Id == request.AlbumId)
                .Select(album => new GetAlbumByIdQueryResult
                {
                    Title = album.Title,
                    ImageUrl = album.ImageUrl,
                    ReleaseDate = album.CreatedDate,
                    TrackCount = album.Tracks.Count(),
                    AlbumType = album.AlbumType.ToString(),
                    TotalDuration = GetAlbumTotalDuration(album.Tracks.Select(x => x.Duration).ToList()),
                    Tracks = GetTrackResults(album.Tracks, album.AlbumArtists.Select(x => x.Artist.Name).ToList())
                })
                .FirstOrDefaultAsync();

            return result is null ? Response<GetAlbumByIdQueryResult>.Error("Album not found!", (int)HttpStatusCode.NotFound)
                                           : Response<GetAlbumByIdQueryResult>.Success(result, (int)HttpStatusCode.OK);
        }

        private static TimeSpan GetAlbumTotalDuration(List<TimeSpan> trackDurations)
            => trackDurations.Aggregate((t1, t2) => t1 + t2);

        private static List<TrackResult> GetTrackResults(ICollection<Track> tracks, List<string> owners)
            =>  tracks
                    .Select(x => new TrackResult
                    {
                        Title = x.Title,
                        Duration = x.Duration,
                        Owners = string.Join(", ", owners)
                    })
                    .ToList();
    }
}
