using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarQueryHandler : IRequestHandler<GetCarPricingByCarQuery, List<GetCarPricingByCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingByCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingByCarQueryResult>> Handle(GetCarPricingByCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarsPricingByCar();
            var newValues = values.Select(x => new GetCarPricingByCarQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingId = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
            }).ToList();
            return newValues;
        }
    }
}
