using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Writter.Help.Validation
{
    class NameValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            cultureInfo = CultureInfo.CurrentCulture;
            //if (char.IsDigit(charString[0]))
            //{
            //    return new ValidationResult(false, $"Поле не может начинаться с цифры");
            //}
            if (!Regex.Match(charString, "^[a-zA-Z][a-zA-Z-\\d]*$").Success)
            {
                return new ValidationResult(false, $"The field can contain only Latin letters, numbers and -");

            }

            return ValidationResult.ValidResult;
        }
    }
}

