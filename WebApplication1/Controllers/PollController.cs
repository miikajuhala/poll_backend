using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

        public PollController (PollContext pollContext)
        {
            _pollContext = pollContext;
        }

        //TODO jos kerkee ennen kertausharjotuksia: try catch + messaget


        // GET all polls including its voteoptions
        [HttpGet]
        public IEnumerable<Poll> Get()
        {
            return _pollContext.Polls
                .Include(poll => poll.VoteOptions)
                .ToList();
        }


        // GET one poll by its id including its voteoptions
        [HttpGet("{id}")]
        public List<Poll> Get(int id)
        {
            //get matchin poll by id from db
            Poll poll = _pollContext.Polls.First(s=>s.Id== id);

            //return poll including polls voteoptions by PollId
             return  _pollContext.Polls.Where(s=>s.Id== id).
                Include(
                 poll => poll.VoteOptions
                .Where(VoteOption => VoteOption.PollId == id))
                .ToList();  
        }

        // POST api/Poll
        //POST object Poll including its VoteOptions as a list and save to database using Entity Framework
        [HttpPost]
        public void Post([FromBody] Poll value)
        {
            //add Poll called value to PollContext 
            _pollContext.Polls.Add(value);
            //and save to db
            _pollContext.SaveChanges();
        }

        // PUT one vote to voteOption by voteOption id
        [HttpPut("/putvote/{id}")]
        public void Put(int id)
        {
            //Get right voteoption from db
            VoteOption voteOpt = _pollContext.VoteOptions.First(s => s.Id == id);
            //increment voteoptions vote counter by one vote
            voteOpt.VoteAmount++;
            //save new vote amount to db
            _pollContext.SaveChanges();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
