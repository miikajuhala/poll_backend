using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("VoteOption")]
    public class VoteOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int VoteAmount { get; set; }


        public int PollId { get; set; }
        [JsonIgnore]
        public Poll? Poll { get; set; }


    }
}