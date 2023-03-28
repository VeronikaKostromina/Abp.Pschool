using System;
using System.ComponentModel.DataAnnotations;

namespace Abp.Pschool.Students
{
    public class CreateUpdateStudentDto
    {
        [Required(ErrorMessage = "First name can not be empty")]
        [StringLength(50, ErrorMessage = "First name can not be more than 50 symbols")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name can not be empty")]
        [StringLength(50, ErrorMessage = "Last name can not be more than 50 symbols")]
        public string? LastName { get; set; }

        [Range(0, 12, ErrorMessage = "Class number should be from 1 to 11")]
        public int ClassNumber { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string? Email { get; set; }

        public StudentMarkType Type { get; set; }
        public Guid TeacherId { get; set; }
    }
}
