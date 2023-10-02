using System.ComponentModel.DataAnnotations;

namespace MyTIME.Views
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
    
}
