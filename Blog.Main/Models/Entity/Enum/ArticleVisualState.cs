﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public enum ArticleVisualState
    {
        Public = 0,
        OnlyOwner = 1,
        OwnerAndFriend =2,
    }
}
