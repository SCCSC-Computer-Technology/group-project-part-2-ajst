namespace WebApp.Models
{
    public class NFLTeam
    {
        public int NFLTeamID { get; set; }
        public string TeamName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference {  get; set; }
        public string Stadium { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

    }
}
