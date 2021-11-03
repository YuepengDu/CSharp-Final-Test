using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest_s3698728.Models
{
    public class Bookings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "RoomID")]
        [ForeignKey("Rooms")]
        [Key]
        public string RoomID { get; set; }
        [Required,Key]
        public DateTime BookingDate { get; set; }
        [Required,StringLength(6)]
        [ForeignKey("Staff")]
        public string StaffID { get; set; }

        public virtual Rooms Room { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
