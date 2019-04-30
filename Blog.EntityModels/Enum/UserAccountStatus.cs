using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.EntityModels
{
    public enum UserAccountStatus
    {
        Normal = 0,
        Abnormity = 1,
        Ban = 2,
        Risk = 3,
        Limitation = 4
    }
}
