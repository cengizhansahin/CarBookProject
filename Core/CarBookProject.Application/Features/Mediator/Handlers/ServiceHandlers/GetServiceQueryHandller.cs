using CarBookProject.Application.Features.Mediator.Queries.ServiceQueries;
using CarBookProject.Application.Features.Mediator.Results.ServiceResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandller : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandller(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                ServiceID = x.ServiceID,
                Description = x.Description,
                IconUrl = x.IconUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
