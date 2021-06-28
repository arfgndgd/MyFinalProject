using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Şifreyi hashler
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Kriptolama classı bulunuyor .net içinde
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; //her kullanıcı için bir key tutar veritabanında
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //hesaplanan hash
            }
        }

        //Hashin verdiğimiz şifre ile eşleşmesini sağlar
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //out vermedik çünkü değerleri biz vereceğiz
        {
            using (var hmac = new HMACSHA512(passwordSalt)) //doğrulama yapacağımız için salt key değerini vermemiz lazım
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
