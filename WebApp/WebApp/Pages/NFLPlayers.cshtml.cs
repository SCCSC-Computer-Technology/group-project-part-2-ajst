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

        public IEnumerable<NFLPlayers>? NFLPlayer { get; set; }//creating a string of suppliers
        [BindProperty(SupportsGet = true)]
        public NFLPlayers? Player { get; set; }

        [BindProperty]
        public string SelectedPlayers {  get; set; }
        public string SelectedNFLPlayer { get; set; } = "";

        public async Task OnGetAsync()//on get funtion runs when my page loads (formload)
        {
            if (string.IsNullOrEmpty(SelectedNFLPlayer))
            {
                NFLPlayer = await database.NFLPlayers.OrderBy(nfl => nfl.TeamId).ToListAsync();
                SelectedNFLPlayer = "All Players";
            }
            else
            {
                NFLPlayer = await database.NFLPlayers.Where(nfl => nfl.Player == SelectedNFLPlayer).OrderBy(nfl => nfl.TeamId).ThenBy(nfl => nfl.Player).ToListAsync();


                NFLPlayers? selectedNFLPlayer = await database.NFLPlayers.FirstOrDefaultAsync(nfl => nfl.Player == SelectedNFLPlayer);

                if (selectedNFLPlayer != null)
                {
                    SelectedNFLPlayer = selectedNFLPlayer.Player;
                }
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
