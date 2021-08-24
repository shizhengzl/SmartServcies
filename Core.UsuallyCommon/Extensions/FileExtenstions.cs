using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 文件扩展
    /// </summary>
    public static class FileExtenstions
    {

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="Path">路劲</param>
        /// <param name="Content">内容</param>
        public static void WriteFile(this string Path, string Content)
        {
            if (!System.IO.File.Exists(Path))
            {
                FileStream fs = new FileStream(Path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
                sw.Write(Content);
                sw.Close();
                fs.Close();
            }
            else
            {
                StreamWriter writer = new StreamWriter(Path, false, Encoding.Unicode);
                writer.Flush();
                writer.Write(Content);
                writer.Close();
            }
        }


        /// <summary>
        /// 根据路劲获取文件内容
        /// </summary>
        /// <param name="Paht">路劲</param>
        /// <returns></returns>
        public static string GetFileContext(this string Paht)
        {
            return File.ReadAllText(Paht, Encoding.Default);
        }
         

        /// <summary>
        /// 获取文件夹下所有扩展文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ext"></param>
        /// <param name="list"></param>
        public static void GetFileByExtension(string filePath, string ext, ref List<string> list)
        {

            if (!System.IO.Directory.Exists(filePath))
                return;
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles(ext);
                foreach (FileInfo chlFile in chldFiles)
                {
                    list.Add(chlFile.FullName);
                }
                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chldFolder in chldFolders)
                {
                    GetFileByExtension(chldFolder.FullName, ext, ref list);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
