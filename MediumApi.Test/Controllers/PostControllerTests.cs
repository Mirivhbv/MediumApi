using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using MediumApi.Controllers;
using MediumApi.Domain.Entities;
using MediumApi.Models;
using MediumApi.Service.Command;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MediumApi.Test.Controllers
{
    public class PostControllerTests
    {
        private readonly IMediator _mediator;
        private readonly PostController _testee;
        private readonly CreatePostModel _createPostModel;
        private readonly Guid _id = Guid.Parse("dbe8d88c-3ec0-4c99-bc4d-3a6b01fd49fb");

        public PostControllerTests()
        {
            var mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
            _testee = new PostController(_mediator, mapper);

            _createPostModel = new CreatePostModel
            {
                Title = "Shalom",
                Description = "Once upon a time, there were living one little girl named Julia."
            };

            var post = new Post
            {
                Id = _id,
                Title = "Shalom",
                Description = "Once upon a time, there were living one little girl named Julia."
            };

            A.CallTo(() => mapper.Map<Post>(A<Post>._)).Returns(post);
            A.CallTo(() => _mediator.Send(A<CreatePostCommand>._, default)).Returns(post);
        }

        [Theory]
        [InlineData("CreatePostAsync: post is null")]
        public async void Post__when_an_exception_occurs__should_return_bad_request(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreatePostCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.Post(_createPostModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);

        }

        [Fact]
        public async void Post__should_return_post()
        {
            var result = await _testee.Post(_createPostModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int) HttpStatusCode.OK);
            result.Value.Should().BeOfType<Post>();
            result.Value.Id.Should().Be(_id);
        }
    }
}