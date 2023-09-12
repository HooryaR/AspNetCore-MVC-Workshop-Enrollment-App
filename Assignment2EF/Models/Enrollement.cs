using System.ComponentModel.DataAnnotations;

namespace Assignment2EF.Models
{
    public class Enrollement
    {
        //[Key]
        public int EnrollementId { get; set; }

        [Required(ErrorMessage = "Please Enter a Name")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Please Enter a Email")]
        public String? Email { get; set; }

        
        public virtual ICollection<Workshop>? Workshops { get; set; }

    }
}
