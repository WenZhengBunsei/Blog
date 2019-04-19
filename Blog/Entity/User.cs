using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Entity
{
    /// <summary>
    /// 用户账户状态。
    /// </summary>
    [Flags]
    public enum UserAccountState
    {
        /// <summary>
        /// 正常：0x00000001
        /// </summary>
        Normal = 1<<0,
        /// <summary>
        /// 异常：0x00000010
        /// </summary>
        Abnormity = 1<<1,
        /// <summary>
        /// 受限：0x00000100
        /// </summary>
        Limitation = 1<<2,
        /// <summary>
        /// 用户申请删除账户：0x00001000
        /// </summary>
        UserDelete = 1<<3,
        /// <summary>
        /// 账户已被锁定：0x00010000
        /// </summary>
        Lock = 1<<4,
        /// <summary>
        /// 管理员封禁了该账户：0x00100000
        /// </summary>
        AdministratorBan = 1<<5,
        /// <summary>
        /// 该账户该账户已被删除：0x10000000
        /// </summary>
        Delete = 1 << 7,
    }
    /// <summary>
    /// 用户类别。
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 浏览者。可评论、观看文章。
        /// </summary>
        Reader,
        /// <summary>
        /// 博客主人。
        /// </summary>
        BlogOwner,
        /// <summary>
        /// 系统管理员。
        /// </summary>
        Administrator
    }
    [Table("Blog_User")]
    public abstract class User : BaseEntityModel
    {
        public User()
        {
            this.UserGUID = Guid.NewGuid();
            UserRegisterTime = DateTime.Now;
            UserLastOnlineTime = DateTime.Now;
        }
        [Key]
        public Guid UserGUID { get; private set; }
        /// <summary>
        /// 用户登陆账号，最大16个字符，最小4个字符。
        /// </summary>
        [StringLength(maximumLength: 16, MinimumLength = 4), Required]
        public String UserLogin { get; set; }
        /// <summary>
        /// 用户密码，以MD5形式存储。
        /// </summary>
        [StringLength(32), Required]
        public String UserPassword { get; set; }
        /// <summary>
        /// 用户当前状态。
        /// </summary>
        [Required]
        public UserAccountState UserAccountState { get; set; }
        /// <summary>
        /// 用户类别。
        /// </summary>
        [Required]
        public UserType UserAccountType { get; set; }
        /// <summary>
        /// 用户注册时间。
        /// </summary>
        [Required]
        public DateTime UserRegisterTime { get; private set; }
        /// <summary>
        /// 用户注册时的IP地址。
        /// </summary>
        [StringLength(15)]
        public String UserRegisterIPAddress { get; set; }
        /// <summary>
        /// 用户最后一次登录时间。
        /// </summary>
        public DateTime? UserLastOnlineTime { get; set; }
        /// <summary>
        /// 用户最后一次在线的IP地址。
        /// </summary>
        [StringLength(15)]
        public String UserLastOnlineIPAddress { get; set; }
        /// <summary>
        /// 用户昵称。
        /// </summary>
        [StringLength(maximumLength: 8, MinimumLength = 2, ErrorMessage = "用户昵称格式错误，应在2~8个字符之间。")]
        public String UserName { get; set; }
        /// <summary>
        /// 用户生日。
        /// </summary>
        public DateTime? UserBirthday { get; set; }
        /// <summary>
        /// 用户省份。
        /// </summary>
        [StringLength(8)]
        public String UserDepartment { get; set; }
        /// <summary>
        /// 用户城市。
        /// </summary>
        [StringLength(8)]
        public String UserCity { get; set; }
        /// <summary>
        ///用户电子信箱。
        /// </summary>
        [StringLength(32,ErrorMessage ="噢噢噢噢噢噢噢噢！好好好....好..好长！的电子邮箱。")]
        public String UserMail { get; set; }
        /// <summary>
        /// 用户的QQ。
        /// </summary>
        [StringLength(15)]
        public String UserQQ { get; set; }
        /// <summary>
        /// 用户的微信账号。
        /// </summary>
        [StringLength(15)]
        public String UserWeChat { get; set; }
        /// <summary>
        /// 用户的手机号码。
        /// </summary>
        [StringLength(11)]
        public String UserPhone { get; set; }
        /// <summary>
        /// 用户的个人简介。
        /// </summary>
        [StringLength(32)]
        public String UserRemark { get; set; }
        /// <summary>
        /// 用户的头像。
        /// </summary>
        [StringLength(64)]
        public String UserIcon { get; set; }
    }
}