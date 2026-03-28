using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NBATeamsModel : PageModel
    {
        private readonly SportsDbContext _context;

        public List<NBATeam> Teams { get; set; } = new List<NBATeam>();
        public List<NBATeam> TopEasternTeams { get; set; } = new List<NBATeam>();
        public List<NBATeam> TopWesternTeams { get; set; } = new List<NBATeam>();

        public NBATeamsModel(SportsDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Teams = await _context.NBATeams
                .OrderBy(t => t.TeamName)
                .ToListAsync();

            TopEasternTeams = Teams
                .Where(t => t.Conference == "Eastern")
                .OrderByDescending(t => t.Wins)
                .ThenBy(t => t.Losses)
                .Take(5)
                .ToList();

            TopWesternTeams = Teams
                .Where(t => t.Conference == "Western")
                .OrderByDescending(t => t.Wins)
                .ThenBy(t => t.Losses)
                .Take(5)
                .ToList();
        }
    }
}