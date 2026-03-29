using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Pages
{
    public class NFLSeasonStatsModel : PageModel
    {
        private readonly SportsDbContext database;

        public NFLSeasonStatsModel(SportsDbContext insertedData)
        {
            database = insertedData;
        }

        public IEnumerable<NFLSeasonStats>? NFLSeasonStat { get; set; }
        [BindProperty]
        public NFLSeasonStats? SeasonStats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? NFLTeamStats { get; set; }

        public string SelectedNFLTeamStats { get; set; } = "";

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(NFLTeamStats))
            {
                NFLSeasonStat = await database.NFLSeasonStats.OrderBy(nfl => nfl.Team).ToListAsync();
            }
            else
            {
                NFLSeasonStat = await database.NFLSeasonStats.Where(nfl => nfl.Team == NFLTeamStats).OrderBy(nfl => nfl.Team).ToListAsync();

                SelectedNFLTeamStats = NFLTeamStats;

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if ((SeasonStats is not null) && ModelState.IsValid)
            {
                database.NFLSeasonStats.Add(SeasonStats);
                await database.SaveChangesAsync();
                return RedirectToPage("/NFLSeasonStats");
            }
            else
            {
                return Page();
            }
        }
    }
}
