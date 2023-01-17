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
    [Required]
    [Column("startingBid")]
    [Display(Name = "Starting bid")]
    public decimal StartingBid { get; set; }
    [Column("winningBid")]
    [Display(Name = "Winning bid")]
    public decimal? WinningBid { get; set; }
    [Required]
    [Column("buyout")]
    [Display(Name = "Buyout price")]
    public decimal Buyout { get; set; }
    [HiddenInput]
    [Display(Name = "Created by")]
    public string? Creator { get; set; }
    [HiddenInput]
    [Display(Name = "Winner")]
    public string? Winner { get; set; }
    [Required]
    [Column("closeDate")]
    [Display(Name = "Auction closes")]
    public DateTime CloseDate { get; set; }

    [Display(Name = "Game")]
    public int GameId { get; set; }
    public virtual Game? Game { get; set; }
}

