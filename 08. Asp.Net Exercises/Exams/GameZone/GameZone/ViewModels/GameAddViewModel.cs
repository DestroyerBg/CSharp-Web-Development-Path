﻿using GameZone.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;
using GameZone.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using static GameZone.Common.GameConstraints;
namespace GameZone.ViewModels
{
    public class GameAddViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [Date(PublishedDateFormat)]
        public string ReleasedOn { get; set; } = null!;

        [Required]
        public int GenreId { get; set; }

        [BindNever]
        public SelectList? Genres { get; set; }

        [Required]
        public string PublisherId { get; set; }


    }
}
