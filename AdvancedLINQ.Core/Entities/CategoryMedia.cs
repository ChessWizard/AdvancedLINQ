using AdvancedLINQ.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class CategoryMedia : BaseEntity<Guid>
    {
        public Guid MediaId { get; set; }

        public Media Media { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
