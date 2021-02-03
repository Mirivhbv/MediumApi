using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;
using MediumApi.Models;
using MediumApi.Service.Command;
using MediumApi.Service.Query;
using Microsoft.AspNetCore.Mvc;

namespace MediumApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        #region Methods

        /// <summary>
        /// Action to retrieve all posts.
        /// </summary>
        /// <returns>Returns a list of posts or an empty list, if there is no post.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> Posts()
        {
            try
            {
                return await _mediator.Send(new GetPostQuery());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Action to create a new post.
        /// </summary>
        /// <returns>Returns the created customer</returns>
        [HttpPost]
        public async Task<ActionResult<Post>> Post(CreatePostModel model)
        {
            try
            {
                return await _mediator.Send(new CreatePostCommand { Post = _mapper.Map<Post>(model) });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}