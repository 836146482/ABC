using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using YellEat.Utility;

namespace YellEat.Model
{
    /// <summary>
    /// 系统配置文件
    /// </summary>
    public class SysConfig
    {
        private static SysConfig _systemConfig;
        private static volatile object _syncobj = new object();
        static SysConfig()
        {
            var file = HttpContext.Current.Server.MapPath("/System.config.xml");
            if (!File.Exists(file))
            {
                using (var fs = File.Create(file))
                {
                    _systemConfig = new SysConfig();
                    _systemConfig.EmailPassword = "hgsoft123";
                    _systemConfig.Email = "yelleat@huagemsoft.com";
                    _systemConfig.EmailAccount = "yelleat";
                    _systemConfig.EmailHost = "smtp.exmail.qq.com";
                    var serializer = new XmlSerializer(typeof(SysConfig));
                    var writer = new StreamWriter(fs);
                    serializer.Serialize(writer, _systemConfig);
                    writer.Close();
                }                              
            }
            else
            {
                var xml = new XmlSerializer(typeof(SysConfig));
                _systemConfig = (SysConfig)xml.Deserialize(new FileStream(file,FileMode.OpenOrCreate));
                _systemConfig._password = DESUtil.Decrypt(_systemConfig._password);
            }
        }

        private SysConfig()
        {

        }
        [XmlIgnore]
        public static SysConfig Instance
        {
            get
            {
                return _systemConfig;
            }
        }        
       
        /// <summary>
        /// 将系统配置信息保存到 System.config 文件
        /// </summary>
        /// <returns></returns>
        public bool SaveToFile()
        {
            try
            {
                if (!File.Exists(HttpContext.Current.Server.MapPath("/System.config.xml")))
                {
                    File.Create(HttpContext.Current.Server.MapPath("/System.config.xml"));
                }
                lock (_syncobj)
                {
                    var serializer = new XmlSerializer(typeof(SysConfig));
                    var writer = new StreamWriter(HttpContext.Current.Server.MapPath("/System.config.xml"));
                    serializer.Serialize(writer, _systemConfig);
                    writer.Close();
                    return true;
                }                
            }
            catch
            {
                return false;
            }
        }
        #region 公有属性
        /// <summary>
        /// 获取或设置邮件服务器
        /// </summary>
        public string EmailHost { get; set; }
        /// <summary>
        /// 获取或设置邮件登录账号
        /// </summary>
        public string EmailAccount { get; set; }

        /// <summary>
        /// 获取或设置邮件密码
        /// </summary>
        public string EmailPassword 
        {
            get
            {
                return _password;
            }
            set
            {
                _password = DESUtil.Encrypt(value);
            }
        }

        private string _password;
        /// <summary>
        /// 获取或设置电子邮件       
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置短信
        /// </summary>
        public string SMSAddress { get; set; }
        #endregion
    }
}