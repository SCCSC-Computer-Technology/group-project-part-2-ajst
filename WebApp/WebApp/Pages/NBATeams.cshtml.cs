using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NBATeamsModel : PageModel
    {
        // db context variable declaration
        private readonly SportsDbContext _context;

        // make the list for the teams
        public List<NBATeam> Teams { get; set; } = new List<NBATeam>();

        // link db context
        public NBATeamsModel(SportsDbContext context)
        {
            _context = context;
        }

        // loads NBATeams table, then orders by team name
        public async Task OnGetAsync()
        {
            Teams = await _context.NBATeams
                .OrderBy(t => t.TeamName)
                .ToListAsync();
        }
    }
}