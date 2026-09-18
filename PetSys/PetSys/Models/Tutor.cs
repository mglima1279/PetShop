using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetSys.Models;

[Table("tb_tutor")]
public partial class Tutor
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PetName { get; set; } = null!;

    public virtual ICollection<Booking> TbBookings { get; set; } = new List<Booking>();
}
