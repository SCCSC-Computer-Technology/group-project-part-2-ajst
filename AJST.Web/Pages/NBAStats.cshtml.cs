using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NBAStatsModel : PageModel
    {
        private readonly SportsDbContext _context;
        public NBAStatsModel(SportsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<NBAStats>? Stats { get; set; }

        public void OnGet()
        {
            Stats = _context.NBAStats.OrderBy(t => t.Team);
        }
    }
}
