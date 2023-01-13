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
    [Required]
    [Column("isActive")]
    [HiddenInput]
    public bool IsActive { get; set; }
    [Column("currentBid")]
    [HiddenInput]
    public decimal CurrentBid { get; set; }
    [Required]
    [Column("startingBid")]
    public decimal StartingBid { get; set; }
    [Column("winningBid")]
    [HiddenInput]
    public decimal? WinningBid { get; set; }
    [Required]
    [Column("buyout")]
    public decimal Buyout { get; set; }
    //public string Creator { get; set; }
    [Required]
    [Column("closeDate")]
    public DateTime CloseDate { get; set; }

    public int GameId { get; set; }
    public virtual Game Game { get; set; }
}

