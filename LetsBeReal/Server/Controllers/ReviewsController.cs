using LetsBeReal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsBeReal.Server.IRepository;

namespace LetsBeReal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
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
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _unitOfWork.Reviewss.GetAll();
            return Ok(reviews);
            //return await _context.Makes.ToListAsync();
        }

        // GET: api/Makes/5
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetReview(int ID)
        {
            // var make = await _context.Makes.FindAsync(ID);
            var review = await _unitOfWork.Reviewss.Get(q => q.ID == ID);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkID=2123754
        [HttpPut("{ID}")]
        public async Task<IActionResult> PutReview(int ID, Reviews review)
        {
            if (ID != review.ID)
            {
                return BadRequest();
            }

            _unitOfWork.Reviewss.Update(review);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!MakeExists(ID))
                if (!await ReviewExists(ID))
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
        public async Task<ActionResult<Reviews>> PostBooking(Reviews review)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Reviewss.Insert(review);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetReview", new { ID = review.ID }, review);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteReview(int ID)
        {
            //var make = await _context.Makes.FindAsync(ID);
            var review = await _unitOfWork.Reviewss.Get(q => q.ID == ID);
            if (review == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Reviewss.Delete(ID);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ReviewExists(int ID)
        {
            //return _context.Makes.Any(e => e.ID == ID);
            var review = await _unitOfWork.Reviewss.Get(q => q.ID == ID);
            return review != null;
        }
    }
}

