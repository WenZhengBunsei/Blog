using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Blog.Main
{
    public  class Tools
    {
        #region MD5
        /// <summary>
        /// 获得字符串的MD5值。
        /// </summary>
        /// <param name="str">需要获得MD5的字符串。</param>
        /// <returns></returns>
        public static string GetStringMd5(string str)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

                var sBuilder = new StringBuilder();

                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        /// <summary>
        /// 获得文件的MD5值。
        /// </summary>
        /// <param name="stream">文件流。</param>
        /// <returns></returns>
        public static string GetStreamMd5(Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(stream);

                var sBuilder = new StringBuilder();

                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        #endregion

        #region Configs
        public readonly static string ServerConfigsPath = Path.Combine("APP_Data", "Server.json");
        public static readonly string DatabaseFilePath = Path.Combine("APP_Data", "BlogDatabase.db");
        public static readonly string RunttingLoggerPath = Path.Combine("APP_Data","RunningLogs");
        public static readonly string UPLoadFilesPath = Path.Combine("APP_Data","Files");
        public static Tools Configs => _tools ?? (_tools = new Tools());
        private static Tools _tools = null;
        private static JObject _jObject = null;
        private Tools()
        {
            using (JsonReader jsonReader = new JsonTextReader(new StreamReader(ServerConfigsPath, Encoding.Default)))
                if (jsonReader.Read())
                    _jObject = JObject.Load(jsonReader);
        }
        /// <summary>
        /// 读取Server.json配置文件信息。
        /// </summary>
        /// <param name="key">JSON属性名。</param>
        /// <returns></returns>
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