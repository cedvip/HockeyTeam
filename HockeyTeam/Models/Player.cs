using HockeyTeam.Models.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HockeyTeam.Models
{
    /// <summary>
    /// Représente un joueur
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Initialise une nouvelle intance de <see cref="PlayerDto"/>
        /// </summary>
        public Player()
        {
            this.Teams = new HashSet<Team>();
        }

        /// <summary>
        /// Contruit un Player à partie d'un PlayerDto
        /// </summary>
        /// <param name="playerDto"></param>
        /// <param name="teamId"></param>
        public Player(PlayerDto playerDto, Team team )
        {
            Name = playerDto.Name;
            LastName = playerDto.LastName;
            Number = playerDto.Number;
            Position = playerDto.Position;
            IsCapitain = playerDto.Is_Capitain;
            Teams = new List<Team> { team };
        }

        /// <summary>
        /// Identifiant du joueur
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        /// <summary>
        /// Numéro du joueur
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Prénom du joueur
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nom du joueur
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Définit si le joueur est capitaine
        /// </summary>
        public bool IsCapitain { get; set; }

        /// <summary>
        /// Réference à l'équipe
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }



    }
}
