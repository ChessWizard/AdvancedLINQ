using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Shared.ResponseObjects.Interfaces
{
    public interface IBaseResponse<TData>
    {
        public TData Data { get; set; }

        public int HttpStatusCode { get; set; }
    }
}
