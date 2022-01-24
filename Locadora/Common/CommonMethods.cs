using System.Text;

namespace Locadora.Common
{
    public static class CommonMethods
    {
        public static string Key = "adef@@kfxcbv@";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var resultado = Encoding.UTF8.GetString(base64EncodeBytes);
            resultado = resultado.Substring(0, resultado.Length - Key.Length);
            return resultado;
        }
    }
}
