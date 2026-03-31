using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NBAScheduleModel : PageModel
    {
        private readonly SportsDbContext _context;

        public NBAScheduleModel(SportsDbContext context)
        {
            _context = context;
        }

        public List<NBASchedule> Games { get; set; } = new();
        public List<NBATeam> Teams { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? TeamName { get; set; }

        public string SelectedTeamName { get; set; } = "";

        public async Task OnGetAsync()
        {

            Teams = await _context.NBATeams
                .OrderBy(t => t.TeamName)
                .ToListAsync();

            if (string.IsNullOrEmpty(TeamName))
            {
                Games = await _context.NBASchedules
                    .OrderBy(g => g.Date)
                    .ThenBy(g => g.StartTime)
                    .ToListAsync();

                SelectedTeamName = "All NBA Games";
            }
            else
            {
                Games = await _context.NBASchedules
                    .Where(g => g.HomeTeam == TeamName || g.VisitorTeam == TeamName)
                    .OrderBy(g => g.Date)
                    .ThenBy(g => g.StartTime)
                    .ToListAsync();

                SelectedTeamName = TeamName;
            }
        }
    }
}