using AdvancedLINQ.Core.Dtos;
using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.SearchMedias
{
    public class SearchMediasQueryResult
    {
        public MediaDto MediaDto { get; set; }

        public List<string> CategoryTitles { get; set; }
    }
}
