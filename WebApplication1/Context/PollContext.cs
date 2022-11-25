using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    //data context luokka
    public class PollContext : DbContext
    {

        public PollContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Poll>()
                  .HasData(
                            new Poll
                            {
                                Id = 1,
                                Title = "Are you a programmer?"
                            },
                            new Poll
                            {
                                Id = 2,
                                Title = "Do you like dogs?"
                            },
                            new Poll
                            {
                                Id = 3,
                                Title = "Do you like coffee?"
                            }

                     );
            modelBuilder.Entity<VoteOption>()
            .HasData(
                            new VoteOption
                            {
                                Id = 1,
                                Title = "yes",
                                VoteAmount = 5,
                                PollId = 1

                            },
                            new VoteOption
                            {
                                Id = 2,
                                Title = "no",
                                VoteAmount = 2,
                                PollId = 1
                            },
                            new VoteOption
                            {
                                Id = 3,
                                Title = "ofcourse!",
                                VoteAmount = 8,
                                PollId = 1
                            },


                            new VoteOption
                            {
                                Id = 4,
                                Title = "yes sirr",
                                VoteAmount = 28,
                                PollId = 2
                            },
                            new VoteOption
                            {
                                Id = 5,
                                Title = "no i like turtles",
                                VoteAmount = 10,
                                PollId = 2
                            },
                            new VoteOption
                            {
                                Id = 6,
                                Title = "ofcourse i do!",
                                VoteAmount = 5,
                                PollId = 2
                            },

                            new VoteOption
                            {
                                Id = 7,
                                Title = "YES",
                                VoteAmount = 50,
                                PollId = 3
                            },
                            new VoteOption
                            {
                                Id = 8,
                                Title = "NO",
                                VoteAmount = 14,
                                PollId = 3
                            },
                            new VoteOption
                            {
                                Id = 9,
                                Title = "I'm addicted to it!",
                                VoteAmount = 75,
                                PollId = 3
                            }

                        );



        }


        public DbSet<Poll> Polls { get; set; }
      
        public DbSet<VoteOption> VoteOptions { get; set; }
    }

}
