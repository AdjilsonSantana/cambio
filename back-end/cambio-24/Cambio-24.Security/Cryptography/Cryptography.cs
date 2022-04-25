using Cambio_24.Security.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Security.Cryptography
{
    public static class Cryptography
    {
        #region Settings

        private static int _iterations = CryptographyConfig.Interations;
        private static int _keySize = CryptographyConfig.KeySize;

        private static string _hash = CryptographyConfig.Hash;
        private static string _salt = CryptographyConfig.Salt;
        private static string _vector = CryptographyConfig.Vector;
        #endregion

        public static string Encrypt(string value)
        {
            return Encrypt<AesManaged>(value, CryptographyConfig.Password);
        }
        public static string Encrypt<T>(string value, string password)
                where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string value)
        {
            return Decrypt<AesManaged>(value, CryptographyConfig.Password);
        }

        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }

        public static bool IsEqual(string cryptografedString, string toVerify)
        {
            try
            {
                var decryptografedString = Decrypt(cryptografedString);

                if (toVerify.Equals(decryptografedString))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public static string GenerateRandomPassword(int passwordSize)
        //{
        //    char[] _password = new char[passwordSize];
        //    string charSet = ""; // Initialise to blank
        //    System.Random _random = new Random();
        //    int counter;

        //    // Build up the character set to choose from
        //    charSet += _totpLowerCase;
        //    charSet += _totpUpperCase;
        //    charSet += _totpNumber;
        //    charSet += _totpSpecials;

        //    for (counter = 0; counter < passwordSize; counter++)
        //    {
        //        _password[counter] = charSet[_random.Next(charSet.Length - 1)];
        //    }

        //    return String.Join(null, _password);
        //}

    }
}
