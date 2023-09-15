using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Shared.Extensions;
using AdvancedLINQ.Shared.ResponseObjects;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.SearchMedias
{
    public class SearchMediasQueryHandler : IRequestHandler<SearchMediasQuery, Response<List<SearchMediasQueryResult>>>
    {
        private readonly IMediaRepository _mediaRepository;

        public SearchMediasQueryHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<Response<List<SearchMediasQueryResult>>> Handle(SearchMediasQuery command, CancellationToken cancellationToken)
        {
            var searchQuery = _mediaRepository.GetAll()
                .Include(x => x.CategoryMedias)
                    .ThenInclude(y => y.Category)
                .Where(x => x.MediaType == command.MediaType)
                .Where(x => x.IMDB >= command.IMDBLowest);

            CategoryTypeFilter(command, searchQuery);
            PublishedYearFilter(command, searchQuery);

            var favoriteMedias = await searchQuery.Select(x => new SearchMediasQueryResult
            {
                CategoryTitles = x.CategoryMedias.Select(x => x.Category.Title)
                                                 .ToList(),
                MediaDto = new()
                {
                    Title = x.Title,
                    Description = x.Description,
                    Director = x.Director,
                    IMDB = x.IMDB,
                    MediaType = x.MediaType,
                    PublishedDate = x.PublishedDate,
                }
            })
            .ToListAsync();

            return favoriteMedias.IsNullOrNotAny() ? Response<List<SearchMediasQueryResult>>.Error("Medias Not Found!", (int)HttpStatusCode.NotFound)
                                                   : Response<List<SearchMediasQueryResult>>.Success(favoriteMedias, (int)HttpStatusCode.OK);
        }

        private void CategoryTypeFilter(SearchMediasQuery request, IQueryable<Media> searchQuery)
        {
            if (request.CategoryType.HasValue)
            {
                searchQuery = searchQuery
                                  .Where(x => x.CategoryMedias.Any(x => x.Category.CategoryType == request.CategoryType.Value));
            }
        }

        private void PublishedYearFilter(SearchMediasQuery request, IQueryable<Media> searchQuery)
        {
            if (request.PublishedMinYear.HasValue && request.PublishedMaxYear.HasValue)
            {
                searchQuery = searchQuery
                                 .Where(x => x.PublishedDate.Year >= request.PublishedMinYear.Value && x.PublishedDate.Year <= request.PublishedMaxYear.Value);
            }

            if (request.PublishedMinYear.HasValue && !request.PublishedMaxYear.HasValue)
            {
                searchQuery = searchQuery
                                .Where(x => x.PublishedDate.Year >= request.PublishedMinYear.Value);
            }

            if (request.PublishedMaxYear.HasValue && !request.PublishedMinYear.HasValue)
            {
                searchQuery = searchQuery
                                .Where(x => x.PublishedDate.Year <= request.PublishedMaxYear.Value);
            }
        }
    }
}
