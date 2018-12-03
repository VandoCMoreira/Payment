using System;
using System.Security.Cryptography;
using System.Text;
using AppAiCorp.Enums;

namespace AppAiCorp.Helpers
{
    /// <summary>
    /// Hash util.
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Bytes the array to hex string.
        /// </summary>
        /// <returns>The array to hex string.</returns>
        /// <param name="source">Source.</param>
        public static string ByteArrayToHexString(byte[] source)
        {
            var str = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
                str.Append(source[i].ToString("x2"));

            return str.ToString();
        }

        /// <summary>
        /// Computes the hash digest.
        /// </summary>
        /// <returns>The hash digest.</returns>
        /// <param name="hashString">Hash string.</param>
        /// <param name="preSharedKey">Pre shared key.</param>
        /// <param name="hashMethod">Hash method.</param>
        public static string ComputeHashDigest(string hashString, string preSharedKey, HashOption hashMethod)
        {
            byte[] numArray;
            var hash = StringToByteArray(hashString);
            var pre = StringToByteArray(preSharedKey);

            if (hashMethod == HashOption.Sha1)
                numArray = (new SHA1CryptoServiceProvider()).ComputeHash(hash);
            else
                throw new InvalidOperationException("Invalid hash method");

            return ByteArrayToHexString(numArray);
        }

        /// <summary>
        /// Strings to byte array.
        /// </summary>
        /// <returns>The to byte array.</returns>
        /// <param name="source">Source.</param>
        /// <param name="useASCII">If set to <c>true</c> use ASCII.</param>
        public static byte[] StringToByteArray(string source, bool useASCII = false)
        {
            Encoding encoding;
            if (!useASCII)
                encoding = new UTF8Encoding();
            else
                encoding = new ASCIIEncoding();
            return encoding.GetBytes(source);
        }
    }
}
