using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.GetSuccessfulEmployees
{
    public class GetSuccesfulEmployeesQueryResult
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public EmployeeTitleType EmployeeTitleType { get; set; }

        public int Score { get; set; }
    }
}
