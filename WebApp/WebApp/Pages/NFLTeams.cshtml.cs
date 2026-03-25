using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NFLTeamsModel : PageModel
    {
        private readonly SportsDbContext _context;
        
        public NFLTeamsModel(SportsDbContext context)
        { 
            _context = context;
        }

        public IEnumerable<NFLTeam>? Teams { get; set; }//Creates String of Teams
        public void OnGet()
        {
            Teams = _context.NFLTeams.OrderBy(t => t.TeamName);
        }
    }
}
