using System.ComponentModel.DataAnnotations;

namespace Eid.MVC.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }
        [Required]
        [Phone]
        [StringLength(13, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 7)]
        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(40, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 10)]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "密码重置问题")]
        public string PasswordQuestion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "密码重置答案")]
        public string PasswordAnswer { get; set; }
    }

    public class EditViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }
        [Required]
        [Phone]
        [StringLength(13, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 7)]
        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [StringLength(40, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 10)]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "密码重置问题")]
        public string PasswordQuestion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "密码重置答案")]
        public string PasswordAnswer { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 4)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码重置问题")]
        public string PasswordQuestion { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 2)]
        [Display(Name = "密码重置答案")]
        public string PasswordAnswer { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须包含至少{2}个、至多{1}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }
}
