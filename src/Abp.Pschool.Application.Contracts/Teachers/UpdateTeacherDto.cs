using System.ComponentModel.DataAnnotations;

namespace Abp.Pschool.Teachers
{
    public class UpdateTeacherDto
    {
        [Required(ErrorMessage = "First name can not be empty")]
        [StringLength(50, ErrorMessage = "First name can not be more than 50 symbols")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name can not be empty")]
        [StringLength(50, ErrorMessage = "Last name can not be more than 50 symbols")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string? Email { get; set; }

        [RegularExpression("^$|^[ 0-9]+$", ErrorMessage = "Only numbers can be used in the phone")]
        public string? Phone { get; set; }

        public string? HomeAddress { get; set; }
    }
}
