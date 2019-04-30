using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class UserAccount:BaseEntity
    {
        [Key]
        public Guid User_AccountGUID { get; private set; } = Guid.NewGuid();
        [StringLength(16,MinimumLength =4,ErrorMessage ="用户名格式错误！")]
        public string User_Login { get; set; }
        [StringLength(32,MinimumLength =32)]
        public string User_Password { get; set; }
        [Required]
        public UserAccountStatus User_AccountStatus { get; set; } = UserAccountStatus.Normal;
        [Required]
        public UserAccountInfo User_Info { get; set; }
        public UserAcccountLevel User_AccountLevel { get; set; } = UserAcccountLevel.Friend; 
        [Required]
        public DateTime User_AccountRegisterTime { get; set; }
        [MaxLength(12), MinLength(12), Required]
        public byte[] User_AccountRegisterIPAddress { get; set; }
        [MaxLength(12),MinLength(12),Required]
        public byte[] User_AccountLastLoginIPAddress { get; set; }
        [Required]
        public DateTime User_AccountLastLoginTime { get; set; }
    }
}
