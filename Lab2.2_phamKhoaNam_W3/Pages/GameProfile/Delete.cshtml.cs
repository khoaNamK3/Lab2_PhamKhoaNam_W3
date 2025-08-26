using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace Lab2._2_phamKhoaNam_W3.Pages.GameProfile
{
    public class DeleteModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        public DeleteModel(ICategoryService categoryService, IGameService gameService)
        {
            _categoryService = categoryService;
            _gameService = gameService;
        }

        public Game GameProfile { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            var roleId = HttpContext.Session.GetString("RoleId");

            if (roleId == null)
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Shared/Login");
            }
            if (roleId != "Manager")
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("./Index");
            }

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

            return NotFound();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameProfile = await _gameService.GetGameById(id.Value);
            if (gameProfile != null)
            {
                GameProfile = gameProfile;
                await _gameService.DeleteGame(GameProfile);
                //await _hubContext.Clients.All.SendAsync("PantherDeleted", PantherProfile.PantherProfileId);
            }

            return RedirectToPage("./Index");
        }

    }
}
