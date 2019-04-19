using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Entity
{
    public abstract class BaseEntityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Row_ID { get; private set; }
    }
}