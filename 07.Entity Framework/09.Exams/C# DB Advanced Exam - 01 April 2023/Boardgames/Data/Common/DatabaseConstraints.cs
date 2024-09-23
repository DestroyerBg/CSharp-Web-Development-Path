namespace Boardgames.Data.Common
{
    public static class DatabaseConstraints
    {
        //BoardGame
        public const int BoardGameNameMinLength = 10;
        public const int BoardGameNameMaxLength = 20;
        public const double BoardGameMinRangeValue = 1;
        public const double BoardGameMaxRangeValue = 10.00;
        public const int BoardGameMinYearPublishedValue = 2018;
        public const int BoardGameMaxYearPublishedValue = 2023;
        public const int BoardGameCategoryTypeMinValue = 0;
        public const int BoardGameCategoryTypeMaxValue = 4;

        //Seller
        public const int SellerNameMinLength = 5;
        public const int SellerNameMaxLength = 20;
        public const int SellerAddressMinLength = 2;
        public const int SellerAddressMaxLength = 30;
        public const string WebsiteRegexPattern = @"www.[A-Za-z0-9\-]+.com";

        //Creator
        public const int CreatorFirstNameMinLength = 2;
        public const int CreatorFirstNameMaxLength = 7;
        public const int CreatorLastNameMinLength = 2;
        public const int CreatorLastNameMaxLength = 7;
    }
}
