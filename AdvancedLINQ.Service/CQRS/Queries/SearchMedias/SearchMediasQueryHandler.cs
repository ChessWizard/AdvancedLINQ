using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Shared.Extensions;
using AdvancedLINQ.Shared.ResponseObjects;
using AdvancedLINQ.Shared.ResponseObjects.Paging;
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
    public class SearchMediasQueryHandler : IRequestHandler<SearchMediasQuery, PagingResult<List<SearchMediasQueryResult>>>
    {
        private readonly IMediaRepository _mediaRepository;

        public SearchMediasQueryHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<PagingResult<List<SearchMediasQueryResult>>> Handle(SearchMediasQuery query, CancellationToken cancellationToken)
        {
            var searchQuery = _mediaRepository.GetAll()
                .Include(x => x.CategoryMedias)
                    .ThenInclude(y => y.Category)
                .Where(x => x.MediaType == query.MediaType)
                .Where(x => x.IMDB >= query.IMDBLowest);

            CategoryTypeFilter(query, searchQuery);
            PublishedYearFilter(query, searchQuery);

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
            .Pagination(query.PageNumber, query.PageSize)
            .ToListAsync();

            return new PagingResult<List<SearchMediasQueryResult>>
            {
                Data = favoriteMedias,
                HttpStatusCode = favoriteMedias.IsNullOrNotAny() ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                PagingMetaData = new(query.PageSize, query.PageNumber, await searchQuery.CountAsync())
            };
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
