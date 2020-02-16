using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Helper
{
    /// <summary>
    /// 文件操作方法帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] FileToBytes(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return new byte[0];
            }

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return buff;
        }

        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址，会覆盖
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void BytesToFile(byte[] buff, string savepath)
        {
            if (System.IO.File.Exists(savepath))
            {
                System.IO.File.Delete(savepath);
            }

            FileStream fs = new FileStream(savepath, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// 判断一个路径是否是文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsPathFile(string path)
        {
            bool tmp = false;
            try
            {
                if (File.Exists(path))
                {
                    tmp = true;
                }
            }
            catch
            {
            }
            return tmp;
        }
        /// <summary>
        /// 判断一个路径是否是文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsPathDirectory(string path)
        {
            bool tmp = false;
            try
            {
                if (Directory.Exists(path))
                {
                    tmp = true;
                }
            }
            catch
            {
            }
            return tmp;
        }
        /// <summary>
        /// 递归：获取当前目录下的文件和文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="paths">记录</param>
        private static void GetFiles(string path, ref List<string> list)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo item in fil)
            {
                list.Add(item.FullName);
            }
            foreach (DirectoryInfo d in dii)
            {
                GetFiles(d.FullName, ref list);
                list.Add(d.FullName);//添加文件夹的路径到列表
            }
        }
        /// <summary>
        /// 获取当前文件路径下全部的文件
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPathFiles(string path)
        {
            List<string> files = new List<string>();
            try
            {
                if (File.Exists(path) || Directory.Exists(path))
                {
                    GetFiles(path, ref files);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return files;
        }
    }
}
