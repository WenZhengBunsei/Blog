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
using Newtonsoft.Json.Linq;
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
            #region 验证
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
                _result.Message = $"上传的文件过大！最大可上传: {_maxUploadSize} KB文件";
                return JsonConvert.SerializeObject(_result);
            }
            #endregion
            using (BlogDBContext blogDBContext = new BlogDBContext())
            {
                    try
                    {
                        string _fileUploadPathStr = AppDomain.CurrentDomain.BaseDirectory + @"App_Upload\";
                        var _configItem_FileUploadPath = Configs.Info["UploadFileSavePostition"];
                        if (_configItem_FileUploadPath.Item1)
                            _fileUploadPathStr = _configItem.Item2;

                        string _attach_MD5 = Tools.GetStreamMD5(_uploadFile.InputStream);
                        string _attach_Name = Tools.GetStringMD5(_uploadFile.FileName);
                        string _attach_Type_MD5 = Tools.GetStringMD5(_uploadFile.ContentType);
                        string _attach_Path = _attach_Type_MD5 + $"\\{_attach_MD5}";

                        if (!Directory.Exists(_attach_Type_MD5))
                            Directory.CreateDirectory(_fileUploadPathStr+_attach_Path);

                    _uploadFile.SaveAs(_fileUploadPathStr + _attach_Path);

                    Attach _attach = new Attach()
                    {
                        Attach_Path = _fileUploadPathStr + _attach_Path,
                         Attach_ExtName = 
                            Attach_OriginalName = _uploadFile.FileName,
                            Attach_Size = _uploadFile.ContentLength
                        };
                    }
                    catch
                    {

                    }
                }
            return JsonConvert.SerializeObject(_result);
        }
    }
}
