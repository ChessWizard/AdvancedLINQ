using AdvancedLINQ.Service.Enums;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.GetSuccessfulEmployees
{
    public class GetSuccessfulEmployeesQuery : IRequest<Response<List<GetSuccesfulEmployeesQueryResult>>>
    {
        public SuccessFilterType SuccessFilterType { get; set; }
    }
}
