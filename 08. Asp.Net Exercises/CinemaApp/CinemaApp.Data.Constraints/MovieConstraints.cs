﻿namespace CinemaApp.Data.Constraints
{
    public static class MovieConstraints
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 50;
        public const int GenreMinLength = 3;
        public const int GenreMaxLength = 10;
        public const int DescriptionMaxLength = 500;
        public const int DirectorNameMinLength = 10;
        public const int DirectorNameMaxLength = 30;
        public const int DurationMinValue = 60;
        public const int DurationMaxValue = 999;
    }
}
