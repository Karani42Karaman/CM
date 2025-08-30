using System.Text.RegularExpressions;

namespace CM.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToSlug(this string text)
        {
            text = text.ToLower()
                       .Replace("ş", "s")
                       .Replace("ı", "i")
                       .Replace("ö", "o")
                       .Replace("ü", "u")
                       .Replace("ç", "c")
                       .Replace("ğ", "g")
                       .Replace("I", "i")   
                       .Replace("I", "i")   
                       .Replace("Ç", "c")


                       ;

            // Boşlukları tire yap
            text = Regex.Replace(text, @"\s+", "-");

            // Harf, rakam ve tire dışındaki karakterleri temizle
            text = Regex.Replace(text, @"[^a-z0-9\-]", "");

            return text;
        }
    }

}
