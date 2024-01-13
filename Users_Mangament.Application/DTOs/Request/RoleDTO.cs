using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.DTOs.Request
{
    public class RoleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب.")]
        [StringLength(100, ErrorMessage = "يجب أن يكون الاسم على الأكثر 100 حرف.")]
        public string? Name { get; set; }

        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
        public List<int> SelectedPermissionIds { get; set; } = new List<int>();

    }

}
