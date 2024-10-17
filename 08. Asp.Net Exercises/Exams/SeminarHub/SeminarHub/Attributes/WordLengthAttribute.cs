using System.ComponentModel.DataAnnotations;
namespace SeminarHub.Attributes
{
    public class WordLengthAttribute : ValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly string errorMessage;
        public WordLengthAttribute(int minValue, int maxValue, string errorMessage)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.errorMessage = errorMessage;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value?.ToString().Length < minValue || value?.ToString().Length > maxValue)
            {
                return new ValidationResult(ErrorMessage = string.Format(errorMessage, minValue, maxValue));
            }

            return ValidationResult.Success;
        }
    }
}
