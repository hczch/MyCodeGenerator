using IOStreamProject.Interface;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace IOStreamProject
{
    public static class FileStreamer //: IFileStreamer
    {
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath">文件路径（包含文件名，文件后缀）</param>
        /// <param name="content">文件内容</param>
        /// <remarks>
        /// filePath：文件可以是一条不存在的路径，接口会根据整个路径创建文件夹和文件
        /// </remarks>
        public static void CreateFile(string filePath, string fileName, string content)
        {
            StringBuilder sb = new StringBuilder(filePath);
            if (!Directory.Exists(sb.ToString()))
            {
                Directory.CreateDirectory(sb.ToString());
            }

            sb.Append($"\\{fileName}");
            if (File.Exists(sb.ToString()))
            {
                File.Delete(fileName);
            }

            using (var stream = new FileStream(sb.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(content);
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Flush();
                stream.Close();
                stream.Dispose();
            }
        }
    }
}