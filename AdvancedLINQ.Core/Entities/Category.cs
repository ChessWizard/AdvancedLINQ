using AdvancedLINQ.Core.Entities.Common;
using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryType CategoryType { get; set; }

        public ICollection<CategoryMedia> CategoryMedias { get; set; }
    }
}
