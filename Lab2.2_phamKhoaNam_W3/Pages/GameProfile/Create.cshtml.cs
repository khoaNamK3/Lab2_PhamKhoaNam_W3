using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2._2_phamKhoaNam_W3.Pages.GameProfile
{
    public class CreateModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        public CreateModel(ICategoryService categoryService, IGameService gameService)
        {
            _categoryService = categoryService;
            _gameService = gameService;
        }

        public async Task<IActionResult> OnGet()
        {
            var roleId = HttpContext.Session.GetString("RoleId");

            if (roleId == null)
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Login");
            }
            if (roleId != "Manager")
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("./Index");
            }
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryId");
            return Page();
        }

        [BindProperty]
        public Game GameProfile { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _gameService.AddNewGameProfile(GameProfile);
            return RedirectToPage("./Index");
        }
    }
}
