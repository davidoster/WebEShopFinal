using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    sealed public class PriceValidationAttribute: ValidationAttribute
    {
        private double _minValue;
        private double _maxValue;
        public PriceValidationAttribute(double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object value) //IsValid(double minValue, double maxValue)
        {
            bool isValid = true;

            if(value != null && ((double)value < _minValue || (double)value > _maxValue))
            {
                isValid = false;
            }
            return isValid;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}