using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Entity.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Display(Name = "Role Name")]
        [Required]
        public string Name { get; set; }
    }
}
