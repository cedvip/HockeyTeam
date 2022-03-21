using Microsoft.AspNetCore.Mvc;
using System.Data;
using HockeyTeam.DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HockeyTeam.Models.Dto;
using System.Threading.Tasks;
using HockeyTeam.Models;

namespace HockeyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly Context _context = null;

        /// <summary>
        /// Innitialise une nouvelle intance de <see cref="TeamController"/>
        /// </summary>
        /// <param name="contexte"></param>
        public TeamController(Context contexte)
        {
            this._context = contexte;
        }

        /// <summary>
        /// Retourne La liste des années
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> Teams()
        {
            var yearList = await this._context.Teams
                .Select(item => item.Year)
                .ToListAsync().ConfigureAwait(false);
            return this.Ok(yearList.OrderByDescending(y => y));
        }

        /// <summary>
        /// Retourne une équipe et ses joueurs
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("{year}")]
        public async Task<IActionResult> Team(int year)
        {
            var model = await this._context.Teams
                .Include(t => t.Players)
                .Where(t => t.Year == year)
                .Select(item => new TeamDto(item))
                .ToListAsync().ConfigureAwait(false);

            return this.Ok(model);
        }

        /// <summary>
        /// Enregistre un nouveau joueur
        /// </summary>
        /// <param name="year"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        [HttpPost("{year}")]
        public async Task<JsonResult> Team(int year, PlayerDto player)
        {
            var team = await _context.Teams.Where(t => t.Year == year)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            //recherche du joueur
            var playerFound = await _context.Players.Where(t => t.PlayerId == player.Id)
                .Include(p => p.Teams)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

            if (playerFound == null)
                _context.Players.AddRange(new Player(player, team));
            else if (!playerFound.Teams.Any(t => t.TeamId == team.TeamId))
            {
                playerFound.Teams.Add(team);
                _context.Entry<Player>(playerFound);
            }

            // Ajout du capitaine
            if (player.Is_Capitain)
            {
                team.CaptainId = player.Id;
                _context.Entry<Team>(team);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return new JsonResult($"Joueur ajouté à l'équipe {year}");
        }
    }
}
