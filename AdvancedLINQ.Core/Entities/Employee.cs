using AdvancedLINQ.Core.Entities.Common;
using AdvancedLINQ.Core.Entities.Common.Interfaces;
using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class Employee : AuditEntity<Guid>, ISoftDeleteEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Amount { get; set; }

        public EmployeeTitleType EmployeeTitleType { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<JobTask> Tasks { get; set; }
    }
}
