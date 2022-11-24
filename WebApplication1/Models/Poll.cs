
namespace WebApplication1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    [Table("Poll")]
    public class Poll
    {

        public Poll()
        {
            VoteOptions = new HashSet<VoteOption>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public ICollection<VoteOption> VoteOptions { get; set; }


    }
}
