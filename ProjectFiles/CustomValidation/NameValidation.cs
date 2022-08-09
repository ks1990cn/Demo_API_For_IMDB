using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomValidation
{
    public class NameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {   
            // This commented code not working fine, need to understand reason
            //    int? a = value as int?;

            //    if (a != null) return false;

            //    return true;

            try
            {
                Convert.ToInt64(value);
                return false;
            }
            catch (Exception)
            {

                return true;
            }
        }
    }
}
