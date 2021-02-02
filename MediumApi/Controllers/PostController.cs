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
using Microsoft.AspNetCore.Mvc;

namespace MediumApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController(IRepository<Post> postRepository, IMediator mediator, IMapper mapper)
        {
            _postRepository = postRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        #region Methods

        /// <summary>
        /// Action to retrieve all posts.
        /// </summary>
        /// <returns>Returns a list of posts or an empty list, if there is no post.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Posts()
        {
            try
            {
                return _postRepository.GetAll().ToList();
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
        public async Task<ActionResult<Post>> Post(CreatePostModel model) // todo: validator
        {
            try
            {
                return await _mediator.Send(new CreatePostCommand {Post = _mapper.Map<Post>(model)});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}