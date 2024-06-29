using CarBookProject.Application.Features.CQRS.Results.CarResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarWithBrandQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var cars = values.Select(x => new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Luggage = x.Luggage,
                Seats = x.Seats,
                Transmission = x.Transmission,
                Km = x.Km,
                CoverImageUrl = x.CoverImageUrl,
                Model = x.Model
            }).ToList();
            return cars;
        }
    }
}
