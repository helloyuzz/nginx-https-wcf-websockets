using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WCF_HttpWinService {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1:IService1 {
        public string GetData(int value) {            
            string tmp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " - aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            return string.Format("You entered-------bbb: {0}，httpMethod:{1}",value,tmp);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if(composite == null) {
                throw new ArgumentNullException("composite");
            }
            if(composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetDateTime(string value) {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " - CrosWcf - " + value;
        }

        public string Ping(string clientValue) {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "-" + clientValue;
        }
    }
}
