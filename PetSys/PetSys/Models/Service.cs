using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetSys.Models;

[Table("tb_service")]
public partial class Service
{
    [Key]
    public int Id { get; set; }

    public string Desc { get; set; } = null!;

    public virtual ICollection<Booking> TbBookings { get; set; } = new List<Booking>();
}
