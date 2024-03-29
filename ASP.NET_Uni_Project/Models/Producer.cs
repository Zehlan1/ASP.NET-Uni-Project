﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Uni_Project.Models;
[Table("Producers")]

public class Producer
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
    [Column("founded")]
    [DataType(DataType.Date)]
    public DateTime Founded { get; set; }

    public virtual ICollection<Game> Games { get; set; }

    public Producer()
    {
        Games = new List<Game>();
    }
}
