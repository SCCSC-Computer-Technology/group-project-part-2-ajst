using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NBAPlayersModel : PageModel
    {
        // declarations
        private readonly SportsDbContext _context;
        public List<NBAPlayer> Players { get; set; } = new();
        public List<NBATeam> Teams { get; set; } = new();

        // allows team id to be used with url when specific team
        // is selected
        [BindProperty(SupportsGet = true)]
        public int? TeamID { get; set; }

        public string SelectedTeamName { get; set; } = "";

        // dbcontext link
        public NBAPlayersModel(SportsDbContext context)
        {
            _context = context;
        }

        // main program
        public async Task OnGetAsync()
        {
            // add the teams to team list
            Teams = await _context.NBATeams.ToListAsync();

            // filter by team id
            if (TeamID == null)
            {
                Players = await _context.NBAPlayers.ToListAsync();
                SelectedTeamName = "All Players";
            }
            else
            {
                // load all players
                Players = await _context.NBAPlayers
                    .Where(p => p.TeamID == TeamID)
                    .ToListAsync();

                // get first team with matching selected team variable
                NBATeam? selectedTeam = await _context.NBATeams
                    .FirstOrDefaultAsync(t => t.NBATeamID == TeamID);

                // assign team name
                if (selectedTeam != null)
                {
                    SelectedTeamName = selectedTeam.TeamName;
                }
            }
        }
    }
}