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
        /// 固定宽度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="fixedLength">固定宽度</param>
        /// <param name="chars">填充字符</param>
        /// <returns></returns>
        public static String ToFixedWidth(this String str, Int32 fixedLength,string chars)
        {
            var express = string.Format("{0}:D{1}",chars.ToStringExtension(), fixedLength);
            return String.Format(String.Format("{{{0}}}", express), str.ToStringExtension());
        }


        /// <summary>
        /// 固定宽度左对齐
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="fixedLength">固定宽度</param>
        /// <returns></returns>
        public static String ToFixedLeftWidth(this String str,Int32 fixedLength)
        {
            var express = string.Format("0,{0}", fixedLength);
            return String.Format(String.Format("{{{0}}}", express), str.ToStringExtension());
        }

        /// <summary>
        /// 固定宽度右对齐
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="fixedLength">固定宽度</param>
        /// <returns></returns>
        public static String ToFixedRightWidth(this String str, Int32 fixedLength)
        {
            var express = string.Format("0,-{0}", fixedLength);
            return String.Format(String.Format("{{{0}}}", express), str.ToStringExtension());
        }


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

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static String ToFirstCharToUpper(this String str)
        {
            if (str.ToStringExtension().Length > 0)
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            return str;
        }
    }
}
