using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using WebApplication1.Context;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {

        private PollContext _pollContext;

        public PollController(PollContext pollContext)
        {
            _pollContext = pollContext;
        }

        

        // GET all polls including its voteoptions
        [HttpGet]
        public ActionResult<Poll> Get()
        {
            try
            {
                //return all polls including voteoptions
               var all = _pollContext.Polls
                    .Include(poll => poll.VoteOptions)
                    .ToList();
                if(all.Any())
                {
                    return Ok(all);
                }
                else
                {
                    return BadRequest();
                }
            }
            //catch error and return er message
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        // GET one poll by its id including its voteoptions
        [HttpGet("{id}")]
        public ActionResult<Poll> Get(int id)
        {
            try
            {
                //get matchin poll by id from db
                Poll poll = _pollContext.Polls.FirstOrDefault(s => s.Id == id);
                //if poll not found, return 404 not found
                if (poll == null)
                {
                    return NotFound("Server: No polls with id: " + id);
                }

                //if ok return poll including polls voteoptions by PollId
                var pollWithOptions =
                    _pollContext.Polls.Where(s => s.Id == id).
                        Include(
                            poll => poll.VoteOptions
                            .Where(VoteOption => VoteOption.PollId == id))
                            .ToList();

                return Ok(pollWithOptions);
            }
            //catch error and return to client
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // POST api/Poll
        //POST object Poll including its VoteOptions as a list and save to database using Entity Framework
        [HttpPost]
        public IActionResult Post([FromBody] Poll value)
        {
    
            //Model exeptions are handled by Entity framework, [Required]
            try
            {
                //add Poll called value to PollContext 
                _pollContext.Polls.Add(value);
                //and save to db
                _pollContext.SaveChanges();
                //return ok if no errors occurred
                return Ok(value);
            }
            catch
            {
                return BadRequest("Internal server error");
            }
        }

        // PUT one vote to voteOption by voteOption id
        [HttpPut("putvote/{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                //Get right voteoption from db
                VoteOption voteOpt = _pollContext.VoteOptions.FirstOrDefault(s => s.Id == id);
                //increment voteoptions vote counter by one vote
                if (voteOpt == null)
                {
                    return NotFound("Server error: voteoption not found");
                }
                //add one vote to voteamount
                voteOpt.VoteAmount++;

                //save new vote amount to db
                _pollContext.SaveChanges();

                return Ok(voteOpt);
            }
            catch 
            {
                return BadRequest("Internal server error");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
