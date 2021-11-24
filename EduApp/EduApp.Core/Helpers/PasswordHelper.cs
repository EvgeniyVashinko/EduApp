using System;
using System.Security.Cryptography;
using System.Text;

namespace EduApp.Core.Helpers
{
    public static class PasswordHelper
    {
        public static string ComputeHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Length must be > 0.", nameof(password));
            }

            var bytes = Encoding.Unicode.GetBytes(password);
            using var sha512 = SHA512.Create();
            var hashed = sha512.ComputeHash(bytes);

            return Encoding.Unicode.GetString(hashed);
        }
    }
}