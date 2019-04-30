using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Blog
{
    public class Attach : BaseEntity
    {
        [Key]
        public Guid Attach_GUID { get; private set; } = Guid.NewGuid();
        [StringLength(32)]
        public string Attach_MD5 { get; set; }
        public int Attach_Size { get; set; } = 0;
        [StringLength(254)]
        public string Attach_OriginalName;
        [StringLength(32)]
        public string Attach_Name { get; set; }
        [StringLength(32)]
        public string Attach_ExtName { get; set; }
        [StringLength(128)]
        public string Attach_Path { get; set; }
    }
}
