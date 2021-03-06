using CA.Assessment.Application.Requests;
using CA.Assessment.Model;
using FluentValidation;

namespace CA.Assessment.Application.Validators;

public sealed class NewBlogPostValidator : AbstractValidator<NewBlogPost>
{
    public NewBlogPostValidator()
    {
        RuleFor(nbp => nbp.Content).NotEmpty().MaximumLength(BlogPost.MAX_CONTENT_SIZE)
            .WithErrorCode(ValidationErrorCodes.BLOG_POST_TOO_LONG);

        RuleFor(nbp => nbp.Author).NotEmpty().WithErrorCode(ValidationErrorCodes.NO_AUTHOR_SPECIFIED_ON_BLOG_POST);

        RuleFor(nbp => nbp.Title).NotEmpty().WithErrorCode(ValidationErrorCodes.NO_TITLE_SPECIFIED_ON_BLOG_POST);

        RuleFor(nbp => nbp.Category).NotEmpty().WithErrorCode(ValidationErrorCodes.NO_CATEGORY_SPECIFIED_ON_BLOG_POST);

        RuleFor(nbp => nbp.Tags).ForEach(t => t.NotEmpty().WithErrorCode(ValidationErrorCodes.BLOG_POST_TAG_IS_EMPTY))
            .WithErrorCode(ValidationErrorCodes.NO_TAGS_SPECIFIED_ON_BLOG_POST);
    }
}
