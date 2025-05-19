using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class LoginFormModel
    {
        [Display(Prompt = "e.g. 2023-6092-71557", Name = "Instructor Number")]
        [Required(ErrorMessage = "Instructor Number is required")]
        [RegularExpression(@"^\d{4}-\d{4}-\d{5}$", ErrorMessage = "Enter a valid instructor number (e.g. 2023-6092-71557)")]
        public string InstructorNumber { get; set; }


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }

        internal static object Email()
        {
            throw new NotImplementedException();
        }
    }
}
