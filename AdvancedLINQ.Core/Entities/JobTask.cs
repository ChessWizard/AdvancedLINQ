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
    public class JobTask : AuditEntity<Guid>, ISoftDeleteEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public StoryPointType StoryPointType { get; set; }

        public TaskType TaskType { get; set; }

        public Enums.TaskStatus TaskStatus { get; set; }

        public bool IsDeleted { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
