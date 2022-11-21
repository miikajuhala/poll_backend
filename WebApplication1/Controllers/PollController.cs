using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        // GET all polls including its voteoptions
        [HttpGet]
        public IEnumerable<Poll> Get()
        {

            return _pollContext.Polls
                .Include(
                poll => poll.VoteOptions)
                .ToList();
        }

        // GET one poll by its id including its voteoptions
        [HttpGet("{id}")]
        public List<Poll> Get(int id)
        {
            Poll poll = _pollContext.Polls.First(s=>s.Id== id);

             return  _pollContext.Polls.Where(s=>s.Id== id).
                Include(
                poll => poll.VoteOptions
                .Where(VoteOption => VoteOption.PollId == id))
                .ToList();  
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Poll value)
        {
            _pollContext.Polls.Add(value);
            _pollContext.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
