using AdvancedLINQ.Core.Entities.Common;
using AdvancedLINQ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Entities
{
    /// <summary>
    /// Film and Series Entity
    /// </summary>
    public class Media : AuditEntity<Guid>
    {
        public string Title { get; set; }

        public MediaType MediaType { get; set; }

        public DateTimeOffset PublishedDate { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public decimal IMDB { get; set; }

        public ICollection<CategoryMedia> CategoryMedias { get; set; }
    }
}
