using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SeminarHub.Attributes
{
    public class DateAttribute : ValidationAttribute
    {
        private string dateFormat;
        private string errorMessage;
        public DateAttribute(string _dateFormat, string _errorMessage)
        {
            dateFormat = _dateFormat;
            errorMessage = _errorMessage;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            bool isValid = DateTime.TryParseExact(value.ToString(), dateFormat, null, DateTimeStyles.None, out DateTime time);
            if (!isValid)
            {
                return new ValidationResult(ErrorMessage = errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
