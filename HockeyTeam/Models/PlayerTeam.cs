namespace HockeyTeam.Models
{
    /// <summary>
    /// Représente la liaison d'un joueur dans une équipe pour une année
    /// </summary>
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
