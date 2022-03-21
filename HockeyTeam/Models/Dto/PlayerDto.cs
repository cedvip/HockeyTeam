namespace HockeyTeam.Models.Dto
{
    /// <summary>
    /// Représente un Player Dto
    /// </summary>
    public class PlayerDto
    {
        public PlayerDto()
        {

        }
        /// <summary>
        /// Initialise une nouvelle instance de <see cref="PlayerDto"/>
        /// </summary>
        /// <param name="player"></param>
        public PlayerDto(Player player)
        {
            this.Id = player.PlayerId;
            this.Name = player.Name;
            this.LastName = player.LastName;
            this.Number = player.Number;
            this.Position = player.Position;
            this.Is_Capitain = player.IsCapitain;
        }

        /// <summary>
        /// Identifiant du joueur
        /// </summary>
        public int Id { get; set; }

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
        public bool Is_Capitain { get; set; }

        ///// <summary>
        ///// Identifiant de l'équipe
        ///// </summary>
        //public int TeamId { get; set; }

        ///// <summary>
        ///// Converti un PlayerDto en Player
        ///// </summary>
        ///// <param name="playerDto"></param>
        ///// <returns></returns>
        //public Player ToEntity(PlayerDto playerDto, int teamId)
        //{
        //    return new Player
        //    {
        //        Name = playerDto.Name,
        //        LastName = playerDto.LastName,
        //        Number = playerDto.Number,
        //        Position = playerDto.Position,
        //        IsCapitain = playerDto.Is_Capitain
        //    };
        //}
    }
}
