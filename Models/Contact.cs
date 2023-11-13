using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMTask.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        [DisplayName("Phone number")]
        public string MobilePhone { get; set; }
        [Required]
        [DisplayName("Job title")]
        public string JobTitle { get; set; }
        [DisplayName("Date of birth")]
        public DateTime BirthDate { get; set; }
    }
}
