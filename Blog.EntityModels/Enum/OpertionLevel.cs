using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.EntityModels
{
    [Flags]
    public enum OpertionLevel
    {
        Low =1<<0,
        Middle =1<<1,
        High =1<<2,
        Importance = 1<<3
    }
}
