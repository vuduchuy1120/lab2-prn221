using System.ComponentModel.DataAnnotations;

namespace Activity_01.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "The year of birth cannot greeter than current year.";
        }

        public override bool IsValid (object value)
        {
            if(value == null)
            {
                return false;
            }
            int number = Int32.Parse(value.ToString());
            return number < 2023;
        }
    }
}
