﻿using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace website_tim_viec_lam.Utilities
{
    public class Functions
    {
        public static int _UserID = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
        public static string getCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dddd HH:mm:ss");
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            //Lặp thêm 5 lần mã hóa xâu đảm bảo tính bảo mật
            //Mỗi lần lặp nhân đôi xâu mã hóa, ở giữa thêm "_"
            //Có thể làm các cách khác để tăng tính bảo mật ở đây
            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + "_" + str);
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
                return false;
            return true;
        }
    }
}
