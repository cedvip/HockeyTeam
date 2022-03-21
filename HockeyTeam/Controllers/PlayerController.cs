using Microsoft.AspNetCore.Mvc;
using System.Data;
using HockeyTeam.DataModels;
using System.Linq;
using HockeyTeam.Models;
using System.Threading.Tasks;

namespace HockeyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly Context _context = null;

        /// <summary>
        /// Innitialise une nouvelle intance de <see cref="PlayerController"/>
        /// </summary>
        /// <param name="contexte"></param>
        public PlayerController(Context contexte)
        {
            this._context = contexte;
        }

        /// <summary>
        /// Retourne une équipe et ses joueurs
        /// </summary>
        /// <param name = "year" ></ param >
        /// < returns ></ returns >
        //[HttpGet()]
        //public async Task<IActionResult> Player(int playerId)
        //{
        //    var playerExist = await _context.Players.Where(t => t.PlayerId == playerId)
        //    .Select(item => new PlayerDto(item))
        //   .FirstOrDefaultAsync()
        //   .ConfigureAwait(false);

        //    return this.Ok(playerExist);
        //}


        /// <summary>
        /// Met un joueur en capitaine
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>      
        [HttpPut("{id},{year}/captain")]
        public async Task<IActionResult> SetCaptain(int id, int year)
        {
            // Récupération du joueur
            var newCapitain = _context.Players.Where(p => p.PlayerId == id).FirstOrDefault();

            // récupération de l'équipe
            var team = _context.Teams.Where(t=>t.Year == year).FirstOrDefault();

            //le capitaine actuel pers sont statut
            if (team.CaptainId > 0)
             _context.Players.Where(p => p.PlayerId == team.CaptainId).FirstOrDefault().IsCapitain=false;            

            //Définition du nouveau capitaine
            newCapitain.IsCapitain = true;
            _context.Entry<Player>(newCapitain);
            team.CaptainId = id;
            _context.Entry<Team>(team);

            //Sauvegarde
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return this.Ok();
        }
    }
}
