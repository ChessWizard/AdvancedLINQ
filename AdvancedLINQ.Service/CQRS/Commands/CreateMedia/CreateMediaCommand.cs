using AdvancedLINQ.Core.Dtos;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Commands.CreateMedia
{
    public class CreateMediaCommand : IRequest<Response<Unit>>
    {
        public List<Guid> CategoryIds { get; set; }
        public MediaDto MediaDto { get; set; }
    }
}
