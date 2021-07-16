using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 获取MD5得值，没有转换成Base64的
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="move">偏移量</param>
        /// <returns>sDataIn加密后的字符串</returns>
        public static string Tomd5(this string str, string move = "")
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] byt, bytHash;
            byt = System.Text.Encoding.UTF8.GetBytes(move + str);
            bytHash = md5.ComputeHash(byt);
            md5.Clear();
            string sTemp = string.Empty;
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp;
        }
         

     

        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="obj">加密字符串</param>
        /// <returns></returns>
        public static System.Security.SecureString ToPasswordToSecureString(this string obj)
        {
            System.Security.SecureString ss = new System.Security.SecureString();
            obj.ToStringExtension().ToArray().ToList().ForEach(x =>
            {
                ss.AppendChar(x);
            });
            ss.MakeReadOnly();
            return ss;
        }


        /// <summary>
        /// 密码解密
        /// </summary>
        /// <param name="obj">加密字符串</param>
        /// <returns></returns>
        public static String ToSecureStringToPassword(this System.Security.SecureString obj)
        {
            string password = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(obj);
            try
            {
                password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return password;
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static String ToFirstCharToLower(this String str)
        {
            if (str.ToStringExtension().Length > 0)
                return str.Substring(0, 1).ToLower() + str.Substring(1);
            return str;
        }
    }
}
