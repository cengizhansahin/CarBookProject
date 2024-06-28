using CarBookProject.Application.Features.CQRS.Queries.BrandQueries;
using CarBookProject.Application.Features.CQRS.Results.BrandResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var brand = new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name
            };
            return brand;
        }
    }
}
