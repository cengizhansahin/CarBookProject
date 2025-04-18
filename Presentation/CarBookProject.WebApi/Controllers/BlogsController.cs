﻿using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            return Ok(await _mediator.Send(new GetBlogQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog bilgisi silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi güncellendi!");
        }
        [HttpGet("GetLast3BlogsWithAuthors")]
        public async Task<IActionResult> GetLast3BlogsWithAuthors()
        {
            return Ok(await _mediator.Send(new GetLast3BlogsWithAuthorsQuery()));
        }
        [HttpGet("GetAllBlogsWithAuthors")]
        public async Task<IActionResult> GetAllBlogsWithAuthors()
        {
            return Ok(await _mediator.Send(new GetAllBlogsWithAuthorsQuery()));
        }
    }
}
