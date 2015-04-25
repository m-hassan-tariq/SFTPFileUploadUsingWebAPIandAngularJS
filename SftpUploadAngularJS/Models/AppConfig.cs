using System.Configuration;

namespace SftpUploadAngularJS.Models
{
    public class AppConfig
    {
        private static string _sftpServerPassword;
        private static string _sftpServerUserName;
        private static string _sftpServerIp;
        private static string _sftpServerPort;
        private static string _sftpPath;

        public static string SftpServerUserName
        {
            get
            {
                if (string.IsNullOrEmpty(_sftpServerUserName))
                    _sftpServerUserName = ConfigurationManager.AppSettings["SFTPServerUserName"];
                return _sftpServerUserName;
            }
        }
        public static string SftpServerPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_sftpServerPassword))
                    _sftpServerPassword = ConfigurationManager.AppSettings["SFTPServerPassword"];
                return _sftpServerPassword;
            }
        }

        public static string SftpServerIp
        {
            get
            {
                if (string.IsNullOrEmpty(_sftpServerIp))
                    _sftpServerIp = ConfigurationManager.AppSettings["SFTPServerIP"];
                return _sftpServerIp;
            }
        }

        public static string SftpServerPort
        {
            get
            {
                if (string.IsNullOrEmpty(_sftpServerPort))
                    _sftpServerPort = ConfigurationManager.AppSettings["SFTPServerPort"];
                return _sftpServerPort;
            }
        }

        public static string SftpPath
        {
            get
            {
                if (string.IsNullOrEmpty(_sftpPath))
                    _sftpPath = ConfigurationManager.AppSettings["SFTPPath"];
                return _sftpPath;
            }
        }
    }
}