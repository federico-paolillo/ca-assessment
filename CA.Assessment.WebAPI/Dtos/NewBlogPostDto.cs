﻿using System.ComponentModel.DataAnnotations;
using CA.Assessment.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace CA.Assessment.WebAPI.Dtos;

[SwaggerSchema(
    WriteOnly = true,
    Title = "New Blog Post Data",
    Required = new[]
    {
        nameof(Title),
        nameof(Content),
        nameof(Author),
        nameof(Category),
        nameof(Tags)
    })]
public sealed class NewBlogPostDto
{
    [SwaggerSchema("Title of the Blog Post", Nullable = false, WriteOnly = true)]
    public string? Title { get; set; }

    [MaxLength(BlogPost.MAX_CONTENT_SIZE)]
    [SwaggerSchema("Content of the Blog Post", Nullable = false, WriteOnly = true)]
    public string? Content { get; set; }

    [SwaggerSchema("Author of the Blog Post", Nullable = false, WriteOnly = true)]
    public string? Author { get; set; }

    [SwaggerSchema("Category of the Blog Post", Nullable = false, WriteOnly = true)]
    public string? Category { get; set; }

    [SwaggerSchema("Tags of the Blog Post", Nullable = false, WriteOnly = true)]
    public IEnumerable<string>? Tags { get; set; }
}
