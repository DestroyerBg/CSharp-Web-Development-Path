namespace GameZone.Common
{
    public static class GameConstraints
    {
        public const int TitleMinLength = 2;
        public const int TitleMaxLength = 50;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 500;
        public const string TitleErrorMessage = "Title should be between 2 and 50 characters long!";
        public const string DescriptionErrorMessage = "Description should be between 10 and 500 characters long!;";
        public const string PublishedDateFormat = "yyyy-MM-dd";
        public const string DateErrorMessage = "Please provide a valid date format (yyyy-MM-dd)";
    }
}
