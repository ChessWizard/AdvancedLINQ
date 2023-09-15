using AdvancedLINQ.Service.CQRS.Queries.SearchMedias;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.Validators
{
    public class SearchMediasValidator : AbstractValidator<SearchMediasQuery>
    {
        public SearchMediasValidator()
        {
            RuleFor(x => x.IMDBLowest).NotEmpty().GreaterThan(default(decimal));
            RuleFor(x => x.MediaType).NotNull().NotEmpty().IsInEnum();
        }
    }
}
