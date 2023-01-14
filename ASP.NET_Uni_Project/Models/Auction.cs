using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Uni_Project.Models;
[Table("Auctions")]
public class Auction
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
    [HiddenInput]
    [Display(Name = "Active")]
    public bool? IsActive { get; set; } = true;
    [HiddenInput]
    public decimal? CurrentBid { get; set; }
    [Required]
    [Column("startingBid")]
    [Display(Name = "Starting bid")]
    public decimal StartingBid { get; set; }
    [Column("winningBid")]
    [HiddenInput]
    [Display(Name = "Winning bid")]
    public decimal? WinningBid { get; set; }
    [Required]
    [Column("buyout")]
    [Display(Name = "Buyout price")]
    public decimal Buyout { get; set; }
    //public string Creator { get; set; }
    [Required]
    [Column("closeDate")]
    [Display(Name = "Auction closes")]
    public DateTime CloseDate { get; set; }

    [Display(Name = "Game")]
    public int GameId { get; set; }
    public virtual Game? Game { get; set; }
}

