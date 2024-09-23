namespace TravelAgency.Data.Common
{
    public static class DatabaseConstraints
    {
        //Customer
        public const int CustomerFullNameMinlength = 4;
        public const int CustomerFullNameMaxlength = 60;
        public const int CustomerEmailMinlength = 6;
        public const int CustomerEmailMaxlength = 50;
        public const int CustomerPhoneNumberExactlyLength = 13;
        public const string CustomerPhoneNumberRegexPattern = @"\+[0-9]{12}";

        //Guide
        public const int GuideFullNameMinLength = 4;
        public const int GuideFullNameMaxLength = 60;
        public const int GuideLanguageEnumMinValue = 0;
        public const int GuideLanguageEnumMaxValue = 4;

        //TourPackage
        public const int TourPackagePackageNameMinLength = 2;
        public const int TourPackagePackageNameMaxLength = 40;
        public const int TourPackageDescriptionMaxLength = 200;
        public const string TourPackagePriceMinValue = "0";
        public static string TourPackagePriceMaxValue = GetDecimalMaxValue();

        private static string GetDecimalMaxValue()
        {
            return decimal.MaxValue.ToString();
        }
    }
}
