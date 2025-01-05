namespace Horizons.Common
{
    public static class DatabaseModelsConstants
    {
        public static class Destination
        {
            public const int NameMinlength = 3;
            public const int NameMaxlength = 80;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
            public const string DateFormat = "dd-MM-yyyy";

        }

        public static class Terrain
        {
            public const int NameMinlength = 3;
            public const int NameMaxlength = 20;
        }
    }
}
