using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.MVC.Models
{
    [Serializable]
    public struct Model_UpdateResult
    {
        public bool IsComplete;
        public bool IsSucceed;
        public string Message;
        public string FileName;
        public int FileSize;
        public string FilePath;
    }
}