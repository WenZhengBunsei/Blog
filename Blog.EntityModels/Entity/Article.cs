using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Blog.EntityModels
{
    public class Article:BaseEntity
    {
        [Key]
        public Guid ArticleGUID { get; set; } = Guid.NewGuid();
        [Required]
        public Guid ArticlePigeonholeClassificationGUID { get; set; }
        [Required]
        public Guid ArticleWriter { get; set;}
        [StringLength(128)]
        public string ArticleContentURL { get; set; }
        [Required]
        public DateTime ArticleCreateTime { get; set; }
        public DataType ArticleLastEditingTime { get; set; }
        public int ArticleReadNum { get; set; } = 0;
        [StringLength(32)]
        public string ArticleTitle { get; set; }
        [StringLength(16)]
        public string ArticleTitlePrefix { get; set; }   
        [StringLength(300)]
        public string ArticleSynopsis { get; set; }
        [StringLength(128)]
        public string ArticleBackgroundImageURL { get; set; }
        public ArticleVisualState ArticleVisualStatus { get; set; } = ArticleVisualState.OnlyOwner;
        public ArticleState ArticleStatus { get; set; } = ArticleState.Editing;
        public int ArticleLoveNumber { get; set; } = 0;
        public int ArticleAversionNumber { get; set; } = 0;
        public bool IsTop { get; set; } = false;
    }
}
