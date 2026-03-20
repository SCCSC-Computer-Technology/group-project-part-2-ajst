using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace WebApp.Pages
{
    public class NBAPlayersModel : PageModel
    {
        // create a list to hold players
        public List<NBAPlayer> Players { get; set; } = new List<NBAPlayer>();

        // iconfig setup
        private readonly IConfiguration _configuration;

        public NBAPlayersModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Name, Position, TeamID, Height, Weight, YearsInLeague, BirthYear, BornIn, DraftYear, DraftRound, DraftPick
                                 FROM nbaCurrentPlayers
                                 ORDER BY Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Players.Add(new NBAPlayer
                            {
                                Name = reader["Name"]?.ToString() ?? "",
                                Position = reader["Position"]?.ToString() ?? "",
                                TeamID = reader["TeamID"] != DBNull.Value ? Convert.ToInt32(reader["TeamID"]) : 0,
                                Height = reader["Height"] != DBNull.Value ? Convert.ToInt32(reader["Height"]) : 0,
                                Weight = reader["Weight"] != DBNull.Value ? Convert.ToInt32(reader["Weight"]) : 0,
                                YearsInLeague = reader["YearsInLeague"] != DBNull.Value ? Convert.ToInt32(reader["YearsInLeague"]) : 0,
                                BirthYear = reader["BirthYear"] != DBNull.Value ? Convert.ToInt32(reader["BirthYear"]) : 0,
                                BornIn = reader["BornIn"]?.ToString() ?? "",
                                DraftYear = reader["DraftYear"] != DBNull.Value ? Convert.ToInt32(reader["DraftYear"]) : 0,
                                DraftRound = reader["DraftRound"] != DBNull.Value ? Convert.ToInt32(reader["DraftRound"]) : 0,
                                DraftPick = reader["DraftPick"] != DBNull.Value ? Convert.ToInt32(reader["DraftPick"]) : 0
                            });
                        }
                    }
                }
            }
        }

        public class NBAPlayer
        {
            public int PlayerID { get; set; }
            public string Name { get; set; } = "";
            public string Position { get; set; } = "";
            public int TeamID { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
            public int YearsInLeague { get; set; }
            public int BirthYear { get; set; }
            public string BornIn { get; set; } = "";
            public int DraftYear { get; set; }
            public int DraftRound { get; set; }
            public int DraftPick { get; set; }
        }
    }
}