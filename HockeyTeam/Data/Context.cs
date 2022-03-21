
using HockeyTeam.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HockeyTeam.DataModels
{
    /// <summary>
    /// Contexte d'entitées
    /// </summary>
    public class Context : DbContext
    {
        #region Constructeur

        public Context([NotNullAttribute] DbContextOptions options) : base(options) { }
        public Context() : base() { }

        #endregion

        #region Methodes internes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  
        }
        #endregion
        /// <summary>
        /// DbSet de l'entité Team
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// DbSet de l'entité Player
        /// </summary>
        public DbSet<Player> Players { get; set; }

    }
}
