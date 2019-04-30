using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog
{
    [ComplexType]
    public class UserAccountInfo
    {
        [StringLength(8,MinimumLength =2),Required]
        public string UserName { get; set; } 
        [MaxLength(11),MinLength(11)]
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
    }
}
