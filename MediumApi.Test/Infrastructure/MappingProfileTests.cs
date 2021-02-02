using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentAssertions;
using MediumApi.Domain.Entities;
using MediumApi.Infrastructure.AutoMapper;
using MediumApi.Models;
using Xunit;

namespace MediumApi.Test.Infrastructure
{
    public class MappingProfileTests
    {
        private readonly CreatePostModel _createPostModel;
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _createPostModel = new CreatePostModel
            {
                Title = "Title",
                Description = "Description"
            };
        }

        [Fact]
        public void Map_post__CreatePostModel__should_have_valid_config()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Post, CreatePostModel>());
            
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_post_to_post__should_have_valid_config()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Post, Post>());

            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map__CreatePostModel__post()
        {
            var post = _mapper.Map<Post>(_createPostModel);

            post.Title.Should().Be(_createPostModel.Title);
            post.Description.Should().Be(_createPostModel.Description);
        }
    }
}