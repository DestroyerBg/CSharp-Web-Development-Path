namespace SeminarHub.Constraints
{
    public class SeminarConstraints
    {
        public const int TopicMinLength = 3;
        public const int TopicMaxLength = 100;
        public const int LecturerMinLength = 5;
        public const int LecturerMaxLength = 60;
        public const int DetailsMinLength = 10;
        public const int DetailsMaxLength = 500;
        public const string DateAndTimeFormat = "dd/MM/yyyy HH:mm";
        public const int DurationMinValue = 30;
        public const int DurationMaxValue = 180;
        public const string TopicErrorMessage = "Topic should be between {0} and {1} characters long!";

        public const string LecturerErrorMessage =
            "Lecturer name should be between {0} and {1} characters long!";

        public const string DetailsErrorMessage =
            "Details text should be between {0} and {1} characters long!";

        public const string DurationErrorMessage =
            "Duration should be between 30 and 180 minutes long!";

        public const string DateWrongFormatErrorMessage = "Wrong duration format";
    }
}
