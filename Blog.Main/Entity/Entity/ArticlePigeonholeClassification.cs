using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Blog
{
    
    public class ArticlePigeonholeClassification:BaseEntity
    {
        [Key]
        public Guid Article_PigeonholeClassificationGUID { get; set; } = Guid.NewGuid();
        [StringLength(16)]
        public string Article_PigeonholeClassificationName { get; set; }
        public Guid Article_PigeonholeClassificationPGUID { get; set; }
        public byte Article_PigeonholeClassificationDeepness { get; set; } = 0;
        public int Article_PigeonholeClassificationClickNum { get; set; } = 0;
    }
}
