namespace ForumApp.Common.DatabaseConstants
{
    public static class CommentConstants
    {
        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 40;
        public const string UsernameErrorMessage = "Username should be between 3 and 40 characters long.";
        public const string ContentErrorMessage = "Content should be between 5 and 2000 characters long.";
        public const int ContentMinLength = 5;
        public const int ContentMaxLength = 2000;

    }
}
