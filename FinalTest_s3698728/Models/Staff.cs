using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest_s3698728.Models
{
    public class Staff
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "StaffID")]
        [RegularExpression(@"^[e][0-9]{5}$",
         ErrorMessage = "Wrong StaffID format.")]
        [StringLength(6)]
        public string StaffID { get; set; }
        [Required,StringLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]{1,29}$",
         ErrorMessage = "First letter must be captial.")]
        public string FirstName { get; set; }
        [Required, StringLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]{1,29}$",
         ErrorMessage = "First letter must be captial.")]
        public string LastName { get; set; }
        [Required, StringLength(320)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Weong email format")]
        public string Email { get; set; }
        [StringLength(10)]
        [RegularExpression(@"^[04]{2}[0-9]{8}$",
         ErrorMessage = "Wrong Mobile Phone format.")]
        public string MobilePhone { get; set; }
        public virtual List<Bookings> Bookings { get; set; }
    }
}
