using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities.Common.Interfaces
{
    public interface IAuditEntity
    {
        DateTimeOffset CreatedDate { get; set; }

        DateTimeOffset? ModifiedDate { get; set; }
    }
}
