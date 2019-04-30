using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        #endregion

        #region Configs
        public readonly static string ServerConfigsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "APP_Config", "Server.json");
        public static Tools Configs { get; private set; } = new Tools();
        private readonly JObject _jObject = null;
        private Tools()
        {
            using (JsonReader _jsonReader = new JsonTextReader(new StreamReader(ServerConfigsPath, Encoding.UTF8)))
                if (_jsonReader.Read())
                    _jObject = JObject.Load(_jsonReader);
        }
        public string this[string key]
        {
            get
            {
                if (_jObject == null)
                    throw new ApplicationException($"配置文件加载失败！请检查：位置为[ {ServerConfigsPath} ]的配置文件是否存在。");
                if (key == null)
                    throw new ArgumentNullException("\"Key\"不可以为空！");
                if (_jObject.TryGetValue(key, out JToken _jsonToken))
                    return _jsonToken.ToString();
                return null;
            }
        }
        #endregion
    }
}