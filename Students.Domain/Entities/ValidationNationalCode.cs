using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Students.Domain.Entities
{
    public class ValidationNationalCode : ValidationAttribute
        //, IClientValidatable
    {

        //protected override ValidationResult IsValid(object value,
        //ValidationContext validationContext)
        //{


        //    bool valid = CheckNationalCode(value.ToString());

        //    if (!valid)
        //    {
        //        return
        //        new ValidationResult(
        //            base.FormatErrorMessage(base.ErrorMessage));

        //    }
        //    return null;
        //}
        public override bool IsValid(object value)
        {
            if (value!= null)
            {
                bool valid = CheckNationalCode(value.ToString());
                if (!valid)
                {
                    ErrorMessage = "لطفا کد ملی را به صورت صحیح وارد کنید ";
                    return false;
                }
                return true;

            }
            return true;
        }



        public bool ValidationForNationalCode(string text)
        {
            var chArray = text.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;
            var controldigit = 0;
            if (c >= 2)
                controldigit = 11 - c;
            else
                controldigit = c;

            var result = (c == 0 && a == c) || (c == 1 && a == 1) || (c > 1 && (a == 11 - c));

            return result;
        }
        public bool CheckDouble(string input)
        {
            double number = 0;
            var result = double.TryParse(input, out number);
            return result;
        }

        public bool CheckNationalCode(string answer)
        {
            bool Codeout = true;
            if (!CheckDouble(answer) || answer.Length != 10 || !ValidationForNationalCode(answer))
            {

              //  MessageBox.Show("لطفا کد ملی را با فرمت صحیح وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Codeout = false;
            }


            return Codeout;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationType = "ValidationNationalCode";
            rule.ErrorMessage = "دقت کنید ";

            yield return rule;
        }
    }
}
