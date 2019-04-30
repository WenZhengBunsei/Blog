using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.EntityModels
{
    public enum ArticleState
    {
        Delete = -1,
        Editing = 0,
        Release = 1,
    }
}
