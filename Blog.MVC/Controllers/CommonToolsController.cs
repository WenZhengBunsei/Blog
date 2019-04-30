using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Blog.MVC.Models;
using Blog.EntityModels;
namespace Blog.MVC.Controllers
{
    public class CommonToolsController : ApiController
    {
        [HttpPost]
        public async Task<string> Upload(HttpPostedFileBase _uploadFile)
        {
            Model_UpdateResult _result = new Model_UpdateResult();
            long _maxUploadSize = 0;
            var _configItem = Configs.Info["UploadFileMaxSize"];
            if (_configItem.Item1)
                _maxUploadSize = Convert.ToInt64(_configItem.Item2);
            if (_uploadFile == null)
            {
                _result.IsComplete = true;
                _result.IsSucceed = false;
                _result.Message="非法的上传请求！";
                return JsonConvert.SerializeObject(_result);
            }
            if (_uploadFile.ContentLength>_maxUploadSize)
            {
                _result.IsComplete = true;
                _result.IsSucceed = false;
                _result.Message = "上传的文件过大！";
                return JsonConvert.SerializeObject(_result);
            }
            using (BlogDBContext blogDBContext = new BlogDBContext())
            {
                using (StreamWriter _uploadFileWriterStream = new StreamWriter(_uploadFile.InputStream))
                {
                    try
                    {
                        Attach _attach = new Attach()
                        {
                            Attach_MD5 = Tools.GetStreamMD5(_uploadFile.InputStream),
                            Attach_Name = Tools.GetStringMD5(_uploadFile.FileName),
                            Attach_OriginalName = _uploadFile.FileName,
                            Attach_Size = _uploadFile.ContentLength
                        };
                    }
                    catch
                    {

                    }
                }
            }
            return JsonConvert.SerializeObject(_result);
        }
    }
}
