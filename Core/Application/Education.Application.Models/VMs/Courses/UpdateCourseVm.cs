using System.ComponentModel.DataAnnotations;

namespace Education.Application.Models.VMs.Courses
{
    public class UpdateCourseVm
    {
        [Required]
        public string Name{ get; set; }
    }
}
