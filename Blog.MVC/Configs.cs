using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Blog.MVC
{
    public class Configs
    {
       
        private const string ConfigPath = @"App_Data\Server.json";
        static Configs()
        {
            
            using (Stream st = new FileStream(AppDomain.CurrentDomain.BaseDirectory + ConfigPath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader _file = new StreamReader(st))
                {
                    string configStr = _file.ReadToEnd();
                    _configModel = JObject.Parse(configStr);

                }
            }
        }
        private Configs()
        {

        }
        private  readonly static JObject _configModel = null;
        private readonly static Configs _cocnfig = new Configs();
        public static Configs Info { get => _cocnfig; }
        public (bool,string,JToken) this[string key]
        {
            get
            {
                string _key = key.ToLower();
                JToken jToken = null;
                if (_configModel.TryGetValue(_key,StringComparison.InvariantCultureIgnoreCase, out jToken)&&jToken!=null)
                {
                    switch (jToken.Type)
                    {
                        case JTokenType.String:
                        case JTokenType.Uri:
                        case JTokenType.Raw:
                        case JTokenType.Boolean:
                        case JTokenType.Date:
                        case JTokenType.Float:
                        case JTokenType.Guid:
                        case JTokenType.Integer:
                            return (true, jToken.ToString(), jToken);
                        default:
                            return (true, null, jToken);
                    }
                }
                return (false,null,null);
            }
        }
    }
}