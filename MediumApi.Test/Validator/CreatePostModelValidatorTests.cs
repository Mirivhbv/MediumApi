using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using MediumApi.Infrastructure.Validators;
using Xunit;

namespace MediumApi.Test.Validator
{
    public class CreatePostModelValidatorTests
    {
        private readonly CreatePostModelValidator _testee;

        public CreatePostModelValidatorTests()
        {
            _testee = new CreatePostModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]
        public void Title__when_shorter_than_five_character__should_have_validation_error(string title)
        {
            _testee.ShouldHaveValidationErrorFor(x => x.Title, title)
                .WithErrorMessage("The title must be at least 5 character long");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]
        public void Description__when_shorter_than_twenty_character__should_have_validation_error(string description)
        {
            _testee.ShouldHaveValidationErrorFor(x => x.Description, description)
                .WithErrorMessage("The description must be at least 20 character long");
        }

        [Fact]
        public void Title__when_equal_or_longer_than_five_character__should_not_have_validation_error()
        {
            _testee.ShouldNotHaveValidationErrorFor(x => x.Title, "Seven");
        }

        [Fact]
        public void Description__when_equal_or_longer_than_twenty_character__should_not_have_validation_error()
        {
            _testee.ShouldNotHaveValidationErrorFor(x => x.Description, "There should be a sentence consist of 20 characters.");
        }
    }
}