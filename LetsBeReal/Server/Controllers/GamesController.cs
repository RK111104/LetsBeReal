using LetsBeReal.Server.IRepository;
using LetsBeReal.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LetsBeReal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // private readonly ApplicationDbContext _context;

        //  public MakesController(ApplicationDbContext context)
        //  {
        //      _context = context;
        //  }

        // GET: api/Makes
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetGames()
        {
            var games = await _unitOfWork.Gamess.GetAll();
            return Ok(games);
            //return await _context.Makes.ToListAsync();
        }

        // GET: api/Makes/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGame(int Id)
        {
            // var make = await _context.Makes.FindAsync(ID);
            var games = await _unitOfWork.Gamess.Get(q => q.Id == Id);

            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkID=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutGame(int Id, Games game)
        {
            if (Id != game.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Gamess.Update(game);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!MakeExists(ID))
                if (!await GameExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkID=2123754
        [HttpPost]
        public async Task<ActionResult<Games>> PostGame(Games game)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();


            await _unitOfWork.Gamess.Insert(game);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetGame", new { Id = game.Id }, game);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGame(int Id)
        {
            //var make = await _context.Makes.FindAsync(ID);
            var game = await _unitOfWork.Gamess.Get(q => q.Id == Id);
            if (game == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Gamess.Delete(Id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> GameExists(int Id)
        {
            //return _context.Makes.Any(e => e.ID == ID);
            var game = await _unitOfWork.Gamess.Get(q => q.Id == Id);
            return game != null;
        }
    }
}

