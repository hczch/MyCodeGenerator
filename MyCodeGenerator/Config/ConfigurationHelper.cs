using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeGenerator.Config
{
    public class ConfigurationHelper 
    {
        private static IConfigurationRoot _instance;
        private static object _lock = new object();

        //防止其他地方调用这个构造函数
        private ConfigurationHelper()
        {

        }

        public static IConfigurationRoot GetInstance()
        {
            //第一层 if (instance == null)是为了减少线程对同步锁锁的竞争
            if (_instance == null)
            {
                lock (_lock)
                {
                    //第二层if(instance == nul)是保证单例。
                    if (_instance == null)
                    {
                        var path = "D:\\User\\Document\\idea\\MyCodeGenerator\\MyCodeGenerator\\Config";
                        var configBuilder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("config.json", optional: false, reloadOnChange: true);
                        _instance = configBuilder.Build();

                        return _instance;
                    }
                }
            }

            return _instance;
        }
        
    }
}
