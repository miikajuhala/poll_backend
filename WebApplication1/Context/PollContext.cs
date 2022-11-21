using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class PollContext : DbContext
    {

        public PollContext(DbContextOptions options) : base(options) { }


        public DbSet<Poll> Polls { get; set; }
        public DbSet<VoteOption> Votes { get; set; }



    }
}
