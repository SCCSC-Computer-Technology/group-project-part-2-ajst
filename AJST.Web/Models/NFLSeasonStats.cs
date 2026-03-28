using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class NFLSeasonStats
    {
        public string Team {  get; set; }
        public byte GP { get; set; }
        public short Total_Yards { get; set; }
        public decimal Total_Yards_Per_Game { get; set; }
        public short Passing_Yards { get; set; }
        public decimal Passing_Yards_Per_Game { get; set; }
        public short Rushing_Yards { get; set; }
        public decimal Rushing_Yards_Per_Game { get; set; }
        public short Points { get; set; }
        public decimal Points_Per_Game { get; set; }
    }
}
