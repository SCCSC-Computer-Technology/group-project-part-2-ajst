using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Pages
{
    public class NFLPlayersModel : PageModel
    {
        private readonly SportsDbContext database;

        public NFLPlayersModel(SportsDbContext insertedData)
        {
            database = insertedData;
        }

        public IEnumerable<NFLPlayers>? NFLPlayer { get; set; } = new List<NFLPlayers>();
        [BindProperty(SupportsGet = true)]
        public NFLPlayers? Player { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedNFLPlayer { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string? TeamId { get; set; }

        public async Task OnGetAsync()
            
        {


            if (!string.IsNullOrEmpty(SelectedNFLPlayer)&& !string.IsNullOrEmpty(TeamId))
            {
                NFLPlayer = await database.NFLPlayers.Where(nfl => nfl.Player == SelectedNFLPlayer && nfl.TeamId == TeamId).OrderBy(nfl => nfl.TeamId == TeamId).ThenBy(nfl => nfl.Player).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(TeamId))
            {
                NFLPlayer = await database.NFLPlayers.Where(nfl => nfl.TeamId == TeamId).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(SelectedNFLPlayer))
            {
                NFLPlayer = await database.NFLPlayers.Where(nfl => nfl.Player == SelectedNFLPlayer).ToListAsync();

            }
            else
            {
                NFLPlayer = await database.NFLPlayers.Where(nfl => nfl.TeamId == TeamId).OrderBy(nfl => nfl.Player).ToListAsync();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if((Player is not null) && ModelState.IsValid)
            {
                database.NFLPlayers.Add(Player);
                await database.SaveChangesAsync();
                return RedirectToPage("/NFLPlayers");
            }
            else
            {
                return Page();
            }
        }
    }
}
