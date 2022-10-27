using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System;

namespace web9.Validation
{
    public class DateValidation : ValidationAttribute
    {
        private const string DateTimeFormat = "dd/MM/yyyy";
        private readonly DateTime date;

        private string today = DateTime.Now.Date.ToShortDateString();

        public DateValidation()
        {
            this.date = DateTime.ParseExact(today, DateTimeFormat, CultureInfo.InvariantCulture);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value >= this.date) return new ValidationResult(this.ErrorMessage);
            return ValidationResult.Success;
        }

    }
}
