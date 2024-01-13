using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Mangament.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب.")]
        [StringLength(100, ErrorMessage = "يجب أن يكون الاسم على الأكثر 100 حرف.")]
        public string? Name { get; set; }

        //[MaxLength(500, ErrorMessage = "يجب أن يكون الوصف على الأكثر 500 حرف.")]
        //public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
