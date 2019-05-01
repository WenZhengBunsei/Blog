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
        [StringLength(8, MinimumLength = 2), Required]
        public string UserName { get; set; }
        [MaxLength(11), MinLength(11)]
        public byte[] UserPhone { get; set; }
        [StringLength(64)]
        public string UserEMail { get; set; }
        [StringLength(16)]
        public string Occupation { get; set; }
        [StringLength(128)]
        public string BlogAddress { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        public bool Sex { get; set; } = true;
        [StringLength(16)]
        public string Location_Nation { get; set; }
        [StringLength(16)]
        public string Location_Province { get; set; }
        [StringLength(16)]
        public string Location_City { get; set; }
        [StringLength(16)]
        public string Location_County { get; set; }
        [StringLength(16)]
        public string Nation { get; set; }
        [StringLength(16)]
        public string Province { get; set; }
        [StringLength(16)]
        public string City { get; set; }
        [StringLength(16)]
        public string County { get; set; }
        [StringLength(32)]
        public string Intro { get; set; }
        [StringLength(128)]
        public string UserIconURL { get; set; }
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
