namespace CinemaApp.Data.Constraints
{
    public class CinemaConstraints
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 30;
        public const string NameErrorMessage = "Cinema name is required.";
        public const string NameTooLongErrorMessage = "Cinema name is too long.";
        public const int LocationMinLength = 3;
        public const int LocationMaxLength = 80;
        public const string LocationErrorMessage = "Location is required.";
        public const string LocationTooLongErrorMessage = "Location is is too long.";

    }
}
