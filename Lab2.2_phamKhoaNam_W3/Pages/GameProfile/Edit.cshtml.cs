using BLL.Interface;
using DAL.Models;
using Lab2._2_phamKhoaNam_W3.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace Lab2._2_phamKhoaNam_W3.Pages.GameProfile
{
    public class EditModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IHubContext<GameHub> _hubContext;
        public EditModel(ICategoryService categoryService, IGameService gameService, IHubContext<GameHub> hubContext)
        {
            _categoryService = categoryService;
            _gameService = gameService;
            _hubContext = hubContext;
        }


        [BindProperty]
        public Game GameProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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

            var gameProfile = await _gameService.GetGameById(id);
            GameProfile = gameProfile;
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryId");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _gameService.UpdateGameById(GameProfile.GameId, GameProfile);
            }
            catch (Exception)
            {
                if (!PantherProfileExists(GameProfile.GameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _hubContext.Clients.All.SendAsync("GameUpdated", GameProfile.GameId);
            return RedirectToPage("./Index");
        }

        private bool PantherProfileExists(int id)
        {
            return (_gameService.GetGameById(id) == null) ? true : false;
        }
    }
}
