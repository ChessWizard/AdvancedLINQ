using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Core.UnitofWork;
using AdvancedLINQ.Shared.Extensions;
using AdvancedLINQ.Shared.ResponseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Commands.CreateMedia
{
    public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, Response<Unit>>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryMediaRepository _categoryMediaRepository;
        private readonly IUnitofWork _unitofWork;

        public CreateMediaCommandHandler(IMediaRepository mediaRepository, ICategoryRepository categoryRepository, IUnitofWork unitofWork, ICategoryMediaRepository categoryMediaRepository)
        {
            _mediaRepository = mediaRepository;
            _categoryRepository = categoryRepository;
            _unitofWork = unitofWork;
            _categoryMediaRepository = categoryMediaRepository;
        }

        public async Task<Response<Unit>> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll()
                .Where(x => request.CategoryIds
                                   .Contains(x.Id))
                .ToListAsync();

            if (categories.IsNullOrNotAny())
                return Response<Unit>.Error("Category not found!", (int)HttpStatusCode.BadRequest);

            Media media = new()
            {
                Title = request.MediaDto.Title,
                MediaType = request.MediaDto.MediaType,
                IMDB = request.MediaDto.IMDB,
                Description = request.MediaDto.Description,
                Director = request.MediaDto.Director,
                PublishedDate = request.MediaDto.PublishedDate,
            };

            await _mediaRepository.AddMediaAsync(media);

            var categoryMedias = categories.Select(category => new CategoryMedia
            {
                CategoryId = category.Id,
                Media = media
            }).ToList();

            await _categoryMediaRepository.AddRangeCategoryMediaAsync(categoryMedias);
            var result = await _unitofWork.SaveChangesAsync();

            return result > 0 ? Response<Unit>.Success((int)HttpStatusCode.Created)
                              : Response<Unit>.Error("Fail!", (int)HttpStatusCode.BadRequest);
        }
    }
}
