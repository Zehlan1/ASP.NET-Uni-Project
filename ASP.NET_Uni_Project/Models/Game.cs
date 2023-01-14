using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Uni_Project.Models;
[Table("Games")]
public class Game
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [Column("title")]
    public string Title { get; set; }
    [Required]
    [Column("description")]
    public string Description { get; set; }
    [DataType(DataType.Date)]
    [Required]
    [Column("release")]
    public DateTime Release { get; set; }

    [Display(Name = "Producer")]
    public int ProducerId { get; set; }
    public virtual Producer? Producer { get; set; }

    [Display(Name = "Game Series")]
    public int GameSerieId { get; set; }
    public virtual GameSerie? GameSerie { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; }

    public Game()
    {
        Auctions = new List<Auction>();
    }
}
