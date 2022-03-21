using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HockeyTeam.Models
{
    /// <summary>
    /// Représente une équipe
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Initialise une nouvelle intance de <see cref="Team"/>
        /// </summary>
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        /// <summary>
        /// Identifiannt de l'équipe
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        /// <summary>
        /// Capitaine de l'équipe
        /// </summary>
        public string Coach { get; set; }

        /// <summary>
        /// Année
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Identifiant du capitaine
        /// </summary>
        public int CaptainId { get; set; } = 0;

        /// <summary>
        /// Référence la liste des joueurs de l'équipe
        /// </summary>
        public virtual ICollection<Player> Players { get; set; }
    }
}
