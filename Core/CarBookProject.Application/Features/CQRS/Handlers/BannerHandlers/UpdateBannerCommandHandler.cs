using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _bannerRepository.GetByIdAsync(command.BannerID);
            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;
            await _bannerRepository.UpdateAsync(value);
        }
    }
}
