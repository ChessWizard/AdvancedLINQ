using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Shared.Extensions;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AdvancedLINQ.Core.Enums;
using AdvancedLINQ.Core.UnitofWork;
using System.Security.Cryptography.X509Certificates;

namespace AdvancedLINQ.Service.CQRS.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Response<Unit>>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly IUnitofWork _unitofWork;

        public CreateAlbumCommandHandler(IAlbumRepository albumRepository, IArtistRepository artistRepository, IUnitofWork unitofWork, ITrackRepository trackRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _unitofWork = unitofWork;
            _trackRepository = trackRepository;
        }

        public async Task<Response<Unit>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.GetAll()
                .Where(x => request.ArtistIds.Contains(x.Id))
                .ToListAsync();

            if (artists.IsNullOrNotAny())
                return Response<Unit>.Error("Artist or Artists not found!", (int)HttpStatusCode.NotFound);

            var tracks = request.Tracks.Select(x => new Track
            {
                Title = x.Title,
                Duration = x.Duration,
                TrackUrl = x.TrackUrl,
                ImageUrl = x.ImageUrl,
            }).ToList();

            await _trackRepository.AddRangeTrackAsync(tracks);

            Album album = new()
            {
                Title = request.Title,
                AlbumType = request.Tracks.Count() > 1 ? AlbumType.Album : AlbumType.Single,
                ImageUrl = request.ImageUrl,
                Tracks = tracks,
                CreatedDate = request.ReleaseDate
            };

            await _albumRepository.AddAlbumAsync(album);

            var albumArtists = artists.Select(x => new AlbumArtist
            {
                Album = album,
                ArtistId = x.Id,
            }).ToList();

            await _albumRepository.AddRangeAlbumArtistAsync(albumArtists);
            await _unitofWork.SaveChangesAsync();
            return Response<Unit>.Success(Unit.Value, (int)HttpStatusCode.Created);
        }
    }
}
