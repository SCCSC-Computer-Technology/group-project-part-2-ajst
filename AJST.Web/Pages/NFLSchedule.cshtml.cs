using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NFLScheduleModel : PageModel
    {
        private readonly SportsDbContext _context;

        public NFLScheduleModel(SportsDbContext context)
        {
            _context = context;
        }

        public List<NFLSchedule> Games { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? TeamName { get; set; }

        public string SelectedTeamName { get; set; } = "";

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(TeamName))
            {
                Games = await _context.NFLSchedules
                    .OrderBy(g => g.Week)
                    .ThenBy(g => g.Date)
                    .ToListAsync();

                SelectedTeamName = "All NFL Games";
            }
            else
            {
                Games = await _context.NFLSchedules
                    .Where(g => g.HomeTeam == TeamName || g.AwayTeam == TeamName)
                    .OrderBy(g => g.Week)
                    .ThenBy(g => g.Date)
                    .ToListAsync();

                SelectedTeamName = TeamName;
            }
        }
    }
}