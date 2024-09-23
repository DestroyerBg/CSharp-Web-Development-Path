namespace Trucks.Data.Common
{
    public static class DatabaseConstraints
    {
        //Truck
        public const int TruckRegistrationNumberExactlyLength = 8;
        public const string TruckRegistrationNumberRegexPattern = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int TruckVinNumberExactlyLength = 17;
        public const int TruckTankCapacityMinRange = 950;
        public const int TruckTankCapacityMaxRange = 1420;
        public const int TruckCargoCapacityMinRange = 5000;
        public const int TruckCargoCapacityMaxRange = 29000;
        public const int TruckCategoryTypeMinValue = 0;
        public const int TruckCategoryTypeMaxValue = 3;
        public const int TruckMakeTypeMinValue = 0;
        public const int TruckMakeTypeMaxValue = 4;


        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

    }
}
