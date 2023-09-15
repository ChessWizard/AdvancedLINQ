using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Service.Enums;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedLINQ.Core.Enums;
using TaskStatus = AdvancedLINQ.Core.Enums.TaskStatus;
using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Service.CQRS.Queries.SearchMedias;
using System.Net;
using AdvancedLINQ.Shared.Extensions;

namespace AdvancedLINQ.Service.CQRS.Queries.GetSuccessfulEmployees
{
    public class GetSuccessfulEmployeeQueryHandler : IRequestHandler<GetSuccessfulEmployeesQuery, Response<List<GetSuccesfulEmployeesQueryResult>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobTaskRepository _jobTaskRepository;

        public GetSuccessfulEmployeeQueryHandler(IEmployeeRepository employeeRepository, IJobTaskRepository jobTaskRepository)
        {
            _employeeRepository = employeeRepository;
            _jobTaskRepository = jobTaskRepository;
        }

        public async Task<Response<List<GetSuccesfulEmployeesQueryResult>>> Handle(GetSuccessfulEmployeesQuery request, CancellationToken cancellationToken)
        {
            var taskQuery = _jobTaskRepository.GetAll()
                        .Where(x => x.TaskStatus == TaskStatus.Closed);

            switch (request.SuccessFilterType)
            {
                case SuccessFilterType.Sprint:

                    taskQuery = taskQuery.Where(x => x.CreatedDate >= DateTimeOffset.UtcNow.AddDays(-14) && x.CreatedDate <= DateTimeOffset.UtcNow);
                    break;
                case SuccessFilterType.Monthly:

                    taskQuery = taskQuery.Where(x => x.CreatedDate >= DateTimeOffset.UtcNow.AddMonths(-1) && x.CreatedDate <= DateTimeOffset.UtcNow);
                    break;
                case SuccessFilterType.Yearly:

                    taskQuery = taskQuery.Where(x => x.CreatedDate >= DateTimeOffset.UtcNow.AddYears(-1) && x.CreatedDate <= DateTimeOffset.UtcNow);
                    break;
            }

            var tasks = await taskQuery.ToListAsync();

            if (tasks.IsNullOrNotAny())
                return Response<List<GetSuccesfulEmployeesQueryResult>>.Error("Tasks Not Found!", (int)HttpStatusCode.NotFound);

            var employees = await _employeeRepository.GetAll()
                        .Include(x => x.Tasks)
                        .Where(employee => tasks.Select(x => x.EmployeeId).ToList().Contains(employee.Id))
                        .OrderByDescending(employee => employee.Tasks.Sum(task => (int)task.StoryPointType))
                        .Take(5)
                        .Select(employee => new GetSuccesfulEmployeesQueryResult
                        {
                            FullName = $"{employee.Name}-{employee.Surname}",
                            Age = employee.Age,
                            EmployeeTitleType = employee.EmployeeTitleType,
                            Score = employee.Tasks.Sum(task => (int)task.StoryPointType)
                        })
                        .ToListAsync();

            return employees.IsNullOrNotAny() ? Response<List<GetSuccesfulEmployeesQueryResult>>.Error("Employees Not Found!", (int)HttpStatusCode.NotFound)
                                              : Response<List<GetSuccesfulEmployeesQueryResult>>.Success(employees, (int)HttpStatusCode.OK);
        }
    }
}
