using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
namespace Blog
{
    public class Tools
    {
        #region MD5
        public static string GetStringMD5(string _str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(_str));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public static string GetStreamMD5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(stream);

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i<data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public static bool MD5Compare(string md5_1, string md5_2) =>  StringComparer.InvariantCultureIgnoreCase.Compare(md5_1, md5_2) == 0 ? true:false;
        #endregion
        
    }
}