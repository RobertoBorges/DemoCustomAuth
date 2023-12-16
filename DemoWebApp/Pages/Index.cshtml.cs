using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCustomAuth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //if the user is authenticated, we return all claims to be listed on the page
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Claims"] = User.Claims;
            }
        }

        public IActionResult OnGetAccessDenied()
        {
            // Set a message indicating access was denied
            ViewData["ErrorMessage"] = "Access Denied: You do not have permission to view this resource.";

            return Page();
        }
    }
}