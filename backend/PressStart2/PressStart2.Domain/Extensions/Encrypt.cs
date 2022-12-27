using System.Security.Cryptography;
using System.Text;

namespace PressStart2.Domain.Extensions
{
    public static class Encrypt
    {
        public static string EncryptSenha(this string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return null;

            senha += "bab48ad3-4489-4f4b-9189-9b521af9ec9b";
            var senhaNova = senha;
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(senhaNova));
            var sbString = new StringBuilder();
            foreach (var d in data)
                sbString.Append(d.ToString("x2"));

            return sbString.ToString();
        }
    }
}
