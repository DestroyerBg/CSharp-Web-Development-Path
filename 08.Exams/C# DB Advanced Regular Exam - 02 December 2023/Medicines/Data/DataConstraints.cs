
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Medicines.Data
{
    internal static class DataConstraints
    {
        // Pharmacy
        public const int PharmacyNameMinLength = 2;
        public const int PharmacyNameMaxLength = 50;
        public const int PhoneNumberMaxLength = 14;
        public const string PhoneNumberRegexPattern = @"\([0-9]{3}\) [0-9]{3}\-[0-9]{4}";

        //Medicine
        public const int MedicineNameMinLength = 3;
        public const int MedicineNameMaxLength = 150;
        public const string PriceMinRange = "0.01";
        public const string PriceMaxRange = "1000.00";
        public const int ProducerMinLength = 3;
        public const int ProducerMaxLength = 100;


        //Patient
        public const int PatientFullNameMinLength = 5;
        public const int PatientFullNameMaxLength = 100;
        public const int PatientAgeGroupMinValue = 0;
        public const int PatientAgeGroupMaxValue = 2;
        public const int PatientGenderGroupMinValue = 0;
        public const int PatientGenderGroupMaxValue = 1;

        //Category
        public const int CategoryMinValue = 0;
        public const int CategoryMaxValue = 4;
    }
}
