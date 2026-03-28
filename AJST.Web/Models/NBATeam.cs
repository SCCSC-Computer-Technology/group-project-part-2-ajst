namespace WebApp.Models
{
    public class NBATeam
    {
        public int NBATeamID { get; set; }
        public string TeamName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Arena { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}