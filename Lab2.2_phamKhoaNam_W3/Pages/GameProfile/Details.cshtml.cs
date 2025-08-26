using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2._2_phamKhoaNam_W3.Pages.GameProfile
{
    public class DetailsModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        public DetailsModel(ICategoryService categoryService, IGameService gameService)
        {
            _categoryService = categoryService;
            _gameService = gameService;
        }
        public Game GameProfile { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameProfile = await _gameService.GetGameById(id.Value);

            if (gameProfile is not null)
            {
                GameProfile = gameProfile;

                return Page();
            }
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryId");

            return NotFound();
        }
    }
}
