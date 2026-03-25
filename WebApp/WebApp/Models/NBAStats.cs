namespace WebApp.Models
{
    public class NBAStats
    {
       public string Team { get; set; }
        public byte Games_Played { get; set; }
        public byte Wins { get;set;  }
        public byte Losses { get; set; }
        public decimal Winning_Percentage { get; set; }
        public decimal Minutes_Per_Game { get; set; }
        public decimal Points_Per_Game { get; set; }
        public decimal Field_Goals_Made { get; set; }
        public decimal Field_Goals_Attempted { get; set; }
        public decimal Field_Goal_Percentage { get; set; }
        public decimal Three_Point_Field_Goals_Made { get; set; }
        public decimal Three_Point_Field_Goals_Attempted { get; set; }
        public decimal Three_Point_Percentage { get; set; }
        public decimal Free_Throws_Made { get; set; }
        public decimal Free_Throws_Attempted { get; set; }
        public decimal Free_Throw_Percentage { get; set; }
        public decimal Offensive_Rebounds { get; set; }
        public decimal Defensive_Rebounds { get; set; }
        public decimal Total_Rebounds { get; set; }
        public decimal Assists { get; set; }
        public decimal Turnovers { get; set; }
        public decimal Steals { get; set; }
        public decimal Blocks { get; set; }
        public decimal Blocks_Against {  get; set; }
        public decimal Personal_Fouls { get; set; }
        public decimal Personal_Fouls_Drawn { get; set; }

    }
}
