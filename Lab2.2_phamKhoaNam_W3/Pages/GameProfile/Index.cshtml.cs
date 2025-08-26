using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2._2_phamKhoaNam_W3.Pages.GameProfile
{
    public class IndexModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        public IndexModel(ICategoryService categoryService, IGameService gameService)
        {
            _categoryService = categoryService;
            _gameService = gameService;
        }
        [TempData]
        public string ErrorMessage { get; set; }

        public IList<Game> GameLists { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("RoleId")))
            {
                GameLists = await _gameService.GetAll();
                return Page();
            }
            return RedirectToPage("/Shared/Login");
        }
    }
}
