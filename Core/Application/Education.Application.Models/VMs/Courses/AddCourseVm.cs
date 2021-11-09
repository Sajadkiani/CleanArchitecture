using System.ComponentModel.DataAnnotations;

namespace Education.Application.Models.VMs.Courses
{
    public class AddCourseVm
    {
        [Required]
        public string Name{ get; set; }
    }
}
