using EduApp.Core.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EduApp.Core.Helpers
{
    public static class PasswordHelper
    {
        /// <exception cref="System.ArgumentException"><paramref name="length" /> must be > 0.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        ///     The cryptographic service provider (CSP) cannot be acquired.
        /// </exception>
        public static string GenerateSalt(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be > 0.", nameof(length));
            }

            using var cryptoService = new RNGCryptoServiceProvider();
            var saltBytes = new byte[length];
            cryptoService.GetNonZeroBytes(saltBytes);
            return Encoding.Unicode.GetString(saltBytes);
        }

        /// <exception cref="System.ArgumentNullException"></exception>
        public static string ComputeHash(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException(nameof(salt));
            }

            var hashAlgorithm = new Sha512Hash();
            return hashAlgorithm.CalculateHash(password + salt);
        }

        /// <exception cref="System.ArgumentException"><paramref name="length" /> must be > 0.</exception>
        public static string Generate(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be > 0.", nameof(length));
            }

            var randomString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Trim();
            return length <= randomString.Length ? randomString[..length] : randomString;
        }
    }
}