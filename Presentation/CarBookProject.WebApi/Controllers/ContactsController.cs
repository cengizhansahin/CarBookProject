﻿using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBookProject.Application.Features.CQRS.Queries.ContactQueries;
using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            List<GetContactQueryResult> values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact Bilgisi Silindi");
        }
    }
}
