using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Mangament.Application.DTOs.Request
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب.")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المستخدم على الأكثر 100 حرف.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [EmailAddress(ErrorMessage = "عنوان البريد الإلكتروني غير صالح.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [StringLength(100, ErrorMessage = "يجب أن تكون كلمة المرور على الأقل 6 أحرف.", MinimumLength = 6)]
        public string? Password { get; set; }

        [Phone(ErrorMessage = "رقم الهاتف غير صالح.")]
        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }

        public string? ProfilePicturePath { get; set; } // مسار الصورة على القرص
    }
}

