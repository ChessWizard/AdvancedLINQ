using AdvancedLINQ.Shared.ResponseObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Shared.ResponseObjects.Paging
{
    public class PagingResult<T> : IBaseResponse<T>
    {
        public T Data { get; set; }

        public int HttpStatusCode { get; set; }

        public PagingMetaData PagingMetaData { get; set; }
    }
}
