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
    class LoginValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            cultureInfo = CultureInfo.CurrentCulture;
            //if (char.IsDigit(charString[0]))
            //{
            //    return new ValidationResult(false, $"Поле не может начинаться с цифры");
            //}
            if (!Regex.Match(charString, "^[a-zA-Z][a-zA-Z_\\d]*$").Success)
            {
                return new ValidationResult(false, $"Поле может содержать только латинские буквы, цифры и _");

            }

            return ValidationResult.ValidResult;
        }
    }
    }
