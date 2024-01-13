using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.DTOs.Request
{
    public class PermissionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب.")]
        [StringLength(100, ErrorMessage = "يجب أن يكون الاسم على الأكثر 100 حرف.")]
        public string? Name { get; set; }


    }
}
