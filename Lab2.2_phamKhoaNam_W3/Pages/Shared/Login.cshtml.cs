using BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2._2_phamKhoaNam_W3.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var account = await _userService.Authenticate(Email, Password);

            if (account == null)
            {
                ErrorMessage = "Invaid Email or Password";
                return Page();
            }
            if (account.Role != "Manager" && account.Role != "Developer")
            {
                ErrorMessage = "You do not have permission to access this page.";
                return Page();
            }
            // save on Session

            HttpContext.Session.SetInt32("UserId", account.UserId);
            HttpContext.Session.SetString("RoleId", account.Role);
            HttpContext.Session.SetString("UserEmail", account.Email);

            return RedirectToPage("/GameProfile/Index");
        }
    }
}
