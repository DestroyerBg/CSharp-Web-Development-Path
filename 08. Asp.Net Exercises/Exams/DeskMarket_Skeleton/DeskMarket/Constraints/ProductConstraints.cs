namespace DeskMarket.Constraints
{
    public class ProductConstraints
    {
        public const int ProductNameMinLength = 2;
        public const int ProductNameMaxLength = 60;
        public const int DescriptionMinlength = 10;
        public const int DescriptionMaxlength = 250;
        public const string PriceMinRange = "1.00";
        public const string PriceMaxRange = "3000.00";
        public const string DateFormat = "dd-MM-yyyy";
        public const string ProductPricePrecision = "decimal(18,2)";

        public const string DateFormatError = "Wrong date format.";
        public const string ProductNameErrorMessage = "Product name should be between {0} and {1} characters long";
        public const string DescriptionErrorMessage = "Description should be between {0} and {1} characters long";

    }
}
