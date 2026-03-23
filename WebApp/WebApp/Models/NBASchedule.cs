using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    [Keyless]
    public class NBASchedule
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }

        public string VisitorTeam { get; set; } = "";
        public byte? VisitorPoints { get; set; }

        public string HomeTeam { get; set; } = "";
        public byte? HomePoints { get; set; }

        public string Arena { get; set; } = "";
    }
}