using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Mangament.Application.DTOs.Request
{
    public class UserRoleDTO
    {
        [Required(ErrorMessage = "معرف المستخدم مطلوب")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "معرف الدور مطلوب")]
        public int RoleId { get; set; }

       
    }
}
