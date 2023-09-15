using AdvancedLINQ.Core.Entities.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities.Common
{
    public class AuditEntity<T> : IAuditEntity<T>
    {
        public T Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }        
    }
}
