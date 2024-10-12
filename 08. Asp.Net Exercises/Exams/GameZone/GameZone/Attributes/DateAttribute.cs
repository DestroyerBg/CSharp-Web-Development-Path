using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static GameZone.Common.GameConstraints;
namespace GameZone.Attributes
{
    public class DateAttribute : ValidationAttribute
    {
        private readonly string dateFormat;
        private readonly string errorMessage = DateErrorMessage;

        public DateAttribute(string _dateFormat)
        {
            dateFormat = _dateFormat;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            bool isValid = DateTime.TryParseExact(value?.ToString(), dateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            if (!isValid)
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
