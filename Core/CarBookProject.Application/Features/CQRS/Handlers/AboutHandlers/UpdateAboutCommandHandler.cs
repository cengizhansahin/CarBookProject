﻿using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AboutID);
            value.Description = command.Description;
            value.ImageUrl = command.ImageUrl;
            value.Title = command.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
