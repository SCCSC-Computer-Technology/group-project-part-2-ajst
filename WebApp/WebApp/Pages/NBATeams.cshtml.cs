using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace WebApp.Pages
{
    public class NBATeamsModel : PageModel
    {
        public List<NBATeam> Teams { get; set; } = new List<NBATeam>();

        private readonly IConfiguration _configuration;

        public NBATeamsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT TeamName, Abbreviation, Conference, Arena, Wins, Losses
                                 FROM nbaTeams
                                 ORDER BY TeamName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teams.Add(new NBATeam
                            {
                                TeamName = reader["TeamName"]?.ToString() ?? "",
                                Abbreviation = reader["Abbreviation"]?.ToString() ?? "",
                                Conference = reader["Conference"]?.ToString() ?? "",
                                Arena = reader["Arena"]?.ToString() ?? "",
                                Wins = reader["Wins"] != DBNull.Value ? Convert.ToInt32(reader["Wins"]) : 0,
                                Losses = reader["Losses"] != DBNull.Value ? Convert.ToInt32(reader["Losses"]) : 0
                            });
                        }
                    }
                }
            }
        }

        public class NBATeam
        {
            public int NBATeamID { get; set; }
            public string TeamName { get; set; } = "";
            public string Abbreviation { get; set; } = "";
            public string Conference { get; set; } = "";
            public string Arena { get; set; } = "";
            public int Wins { get; set; }
            public int Losses { get; set; }
        }
    }
}