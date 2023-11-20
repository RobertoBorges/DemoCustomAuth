using DemoCustomAuth.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCustomAuth.Pages
{
    [MyAuth(Role = "Admin")]
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
