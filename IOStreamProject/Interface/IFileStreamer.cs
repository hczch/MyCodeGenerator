using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOStreamProject.Interface
{
    public interface IFileStreamer
    {
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath">文件路径（包含文件名，文件后缀）</param>
        /// <param name="content">文件内容</param>
        /// <remarks>
        /// filePath：文件可以是一条不存在的路径，接口会根据整个路径创建文件夹和文件
        /// </remarks>
        public void CreateFile(string filePath, string fileName, string content);
    }
}
