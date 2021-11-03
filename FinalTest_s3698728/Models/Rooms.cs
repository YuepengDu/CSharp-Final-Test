using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest_s3698728.Models
{
    public class Rooms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "RoomID"),Key]
        [StringLength(8)]
        [RegularExpression(@"^[0-9]{2}.[0-9]{2}.[0-9]{2}$",
         ErrorMessage = "Wrong RoomID format.")]
        public string RoomID { get; set; }
        [Required]
        [Range(2,300)]
        public int Capacity { get; set; }
        [Required]
        public bool HasProjector { get; set; }
        public virtual List<Bookings> Bookings { get; set; }
    }
}
