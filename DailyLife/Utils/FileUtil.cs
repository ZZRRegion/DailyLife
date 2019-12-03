/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：FileUtil
* 创建日期：2019/12/2 14:02:00
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：FileUtil
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace DailyLife.Utils
{
    public static class FileUtil
    {
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        public static string GetLinkPath(string linkPath)
        {
            if (File.Exists(linkPath))
            {
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut wshShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(linkPath);
                return wshShortcut.TargetPath;
            }
            return null;
        }
        /// <summary>
        /// 获取文件的MD5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileMD5(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bys = md5.ComputeHash(fs);
                fs.Close();
                fs.Dispose();
                return bys.ToHexString();
            }
            catch(IOException ioe)
            {
                throw ioe;
            }
        }
        /// <summary>
        /// 获取字符串的MD5
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetStringMD5(string content)
        {
            byte[] bys = Encoding.UTF8.GetBytes(content);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(bys);
            return res.ToHexString();
        }
        public static string ToHexString(this byte[] @this)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < @this.Length; i++)
            {
                sb.Append(@this[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
