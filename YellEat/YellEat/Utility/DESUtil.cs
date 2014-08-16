using System;
using System.IO;
using System.Security.Cryptography;

namespace YellEat.Utility
{
    /// <summary>
    /// DES 类提供 DES 加密和解密功能
    /// </summary>
    public class DESUtil
    {
        //默认密钥向量
        private static byte[] KEY_64= {42, 16, 93, 156, 78, 4, 218, 32};
        private static byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        

        /**/
        /// <summary>
        /// DES 加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <returns>加密成功返回加密后的字符串</returns>
        public static string Encrypt(string encryptString)
        {
            var cryptoProvider = new DESCryptoServiceProvider();
            var ms = new MemoryStream();
            var cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            var sw = new StreamWriter(cst);
            sw.Write(encryptString);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// DE S解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <returns>解密成功返回解密后的字符串</returns>
        public static string Decrypt(string decryptString)
        {
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(decryptString);
            }
            catch
            {
                return null;
            }
            var cryptoProvider = new DESCryptoServiceProvider();
            var ms = new MemoryStream(byEnc);
            var cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
            var sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }


    }
}