using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.GetAlbumById
{
    public class GetAlbumByIdQuery : IRequest<Response<GetAlbumByIdQueryResult>>
    {
        public Guid AlbumId { get; set; }
    }
}
