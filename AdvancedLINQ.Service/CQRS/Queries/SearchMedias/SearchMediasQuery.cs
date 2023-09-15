using AdvancedLINQ.Core.Enums;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.SearchMedias
{
    public class SearchMediasQuery : IRequest<Response<List<SearchMediasQueryResult>>>
    {
        public MediaType MediaType { get; set; }

        public CategoryType? CategoryType { get; set; }

        public decimal IMDBLowest { get; set; }

        public int? PublishedMinYear { get; set; }

        public int? PublishedMaxYear { get; set; }
    }
}
