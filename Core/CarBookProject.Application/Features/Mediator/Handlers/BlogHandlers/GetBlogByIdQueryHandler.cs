﻿using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var newValue = new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                AuthorId = value.AuthorId,
                BlogTitle = value.BlogTitle,
                CategoryId = value.CategoryId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Description = value.Description,
            };
            return newValue;
        }
    }
}
