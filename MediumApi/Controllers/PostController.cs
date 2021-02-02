using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediumApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post> _postRepository;

        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
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



        #endregion
    }
}