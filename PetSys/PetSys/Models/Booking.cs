using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetSys.Models;

[Table("tb_booking")]
public partial class Booking
{
    [Key]
    public int Id { get; set; }

    public DateTime Datetime { get; set; }

    public int IdTutor { get; set; }

    public int IdService { get; set; }

    public virtual Service? IdServiceNavigation { get; set; } = null!;

    public virtual Tutor? IdTutorNavigation { get; set; } = null!;
}
