using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Renci.SshNet;
using SftpUploadAngularJS.Models;

namespace SftpUploadAngularJS.Controllers
{
    public class UploadController : ApiController
    {
        [System.Web.Http.HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["file"];
                bool folderExists = Directory.Exists(HttpContext.Current.Server.MapPath("~/UploadedDocuments"));
                if (!folderExists)
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/UploadedDocuments"));
                var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedDocuments"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);

                if (File.Exists(fileSavePath))
                {
                    using (SftpClient sftpClient = new SftpClient(AppConfig.SftpServerIp, Convert.ToInt32(AppConfig.SftpServerPort), AppConfig.SftpServerUserName, AppConfig.SftpServerPassword))
                    {
                        sftpClient.Connect();
                        if (!sftpClient.Exists(AppConfig.SftpPath + "UserID"))
                        {
                            sftpClient.CreateDirectory(AppConfig.SftpPath + "UserID");
                        }

                        Stream fin = File.OpenRead(fileSavePath);
                        sftpClient.UploadFile(fin, AppConfig.SftpPath + "/" + httpPostedFile.FileName, true);
                        fin.Close();
                        sftpClient.Disconnect();
                    }
                }
            }
        }
    }
}
