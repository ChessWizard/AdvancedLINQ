using AdvancedLINQ.Core.Enums;
using AdvancedLINQ.Shared.ResponseObjects;
using AdvancedLINQ.Shared.ResponseObjects.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.SearchMedias
{
    public class SearchMediasQuery : IRequest<PagingResult<List<SearchMediasQueryResult>>>
    {
        public MediaType MediaType { get; set; }

        public CategoryType? CategoryType { get; set; }

        public decimal IMDBLowest { get; set; }

        public int? PublishedMinYear { get; set; }

        public int? PublishedMaxYear { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 100; 
    }
}
