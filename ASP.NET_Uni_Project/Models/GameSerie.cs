using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Uni_Project.Models;
[Table("GameSeries")]
public class GameSerie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [Column("name")]
    public string Name { get; set; }
    [Required]
    [Column("description")]
    public string Description { get; set; }
    [Column("genre")]
    public string? Genre { get; set; }

    public virtual ICollection<Game> Games { get; set; }

    public GameSerie()
    {
        Games = new List<Game>();
    }
}
