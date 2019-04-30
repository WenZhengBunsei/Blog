using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Blog.EntityModels
{
    public class BaseEntity
    {
        public int OrderNumber { get; set; } = 0;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("Row_ID")]
        public int Row_ID { get;private set; }
    }
}
