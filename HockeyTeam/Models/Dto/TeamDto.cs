using System.Collections.Generic;
using System.Linq;

namespace HockeyTeam.Models.Dto
{
    /// <summary>
    /// Représente un Team Dto
    /// </summary>
    public class TeamDto
    {
        public TeamDto()
        {

        }
        /// <summary>
        /// Initialise une nouvelle instance de <see cref="TeamDto"/>
        /// </summary>
        /// <param name="player"></param>
        public TeamDto(Team team)
        {
            this.Id=team.TeamId;
            this.Coach=team.Coach;
            this.Year=team.Year;
            this.CaptainId = team.CaptainId;
            this.Players = team?.Players.Select(item => new PlayerDto(item)).ToList();
        }

        /// <summary>
        /// Identifiannt de l'équipe
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Capitaine de l'équipe
        /// </summary>
        public string Coach { get; set; }

        /// <summary>
        /// Année
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// identifiant du capitaine
        /// </summary>
        public int CaptainId { get; set; }

        /// <summary>
        /// Référence la liste des joueurs de l'équipe
        /// </summary>
        public List<PlayerDto> Players { get; set; }


    }
}
