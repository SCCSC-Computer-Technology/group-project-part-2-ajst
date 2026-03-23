using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Keyless]
    public class NFLSchedule
    {
        [Column("week")]
        public byte Week { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("away_team")]
        public string AwayTeam { get; set; } = "";

        [Column("home_team")]
        public string HomeTeam { get; set; } = "";

        [Column("site_note")]
        public string? SiteNote { get; set; }

        [Column("kickoff_et")]
        public string KickoffET { get; set; } = "";

        [Column("kickoff_local")]
        public string KickoffLocal { get; set; } = "";

        [Column("network")]
        public string Network { get; set; } = "";
    }
}