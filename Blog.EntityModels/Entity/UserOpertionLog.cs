using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.EntityModels
{
    public class UserOpertionLog:BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        new public int Row_ID { get; set; }
        [Required]
        public Guid OpertionUserGUID { get; set; }
        public DateTime OpertionTime { get; set; }
        public OpertionLevel OpertionLevel { get; set; }
        [Required,StringLength(1024)]
        public string OpertionContent { get; set; }
    }
}
