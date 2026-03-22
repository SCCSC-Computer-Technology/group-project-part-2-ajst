namespace WebApp.Models
{
    public class NBAPlayer
    {
        public short PlayerID { get; set; } 
        public string Name { get; set; }
        public byte TeamID { get; set; }       
        public string Position { get; set; }
        public byte Height { get; set; }       
        public short Weight { get; set; }   
        public byte YearsInLeague { get; set; }
        public short BirthYear { get; set; }
        public string BornIn { get; set; }
        public short DraftYear { get; set; }
        public byte DraftRound { get; set; }   
        public byte DraftPick { get; set; }    
        public string HeadshotUrl { get; set; }
    }
}