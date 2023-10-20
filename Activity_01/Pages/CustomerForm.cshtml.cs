using Activity_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activity_01.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public Customer customerInfo { get; set; }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Message = "Error on input data";
            }
        }
    }
}
