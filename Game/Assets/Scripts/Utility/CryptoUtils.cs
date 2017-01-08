using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class CryptoUtils
{
    internal const string key = "bxzfHEW80YqDlAURcnrSLzSi5n4hx8nSW5R5A95fBwc=";
    private static RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();

    private static RijndaelManaged NewRijndaelManaged(Byte[] iv)
    {
        if (iv == null)
            throw new ArgumentNullException("bad iv");

        var aesAlg = new RijndaelManaged();
        aesAlg.Key = Convert.FromBase64String(key);
        aesAlg.IV = iv;

        return aesAlg;
    }

    public static string EncryptNewIV(string plaintext)
    {
        Byte[] iv = new Byte[16];
        random.GetBytes(iv);

        return Encrypt(plaintext, iv);
    }

    public static string Encrypt(string plaintext, Byte[] iv)
    {
        if (string.IsNullOrEmpty(plaintext))
            throw new ArgumentNullException("nothing to encrypt detected");

        var aesAlg = NewRijndaelManaged(iv);

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        var msEncrypt = new MemoryStream();

        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plaintext);
            }
        }

        // cipher + iv
        return Convert.ToBase64String(msEncrypt.ToArray()) + Convert.ToBase64String(iv);
    }

    public static string Decrypt(string ciphertext,  Byte[] iv)
    {
        if (string.IsNullOrEmpty(ciphertext))
            throw new ArgumentNullException("no input?");

        string text;

        var aesAlg = NewRijndaelManaged(iv);

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        var cipher = Convert.FromBase64String(ciphertext);

        using (var msDecrypt = new MemoryStream(cipher))
        {
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                        text = srDecrypt.ReadToEnd();
                }
            }
        }

        return text;
    }
}
