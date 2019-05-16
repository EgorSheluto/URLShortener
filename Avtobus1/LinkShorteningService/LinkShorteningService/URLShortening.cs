using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LinkShorteningService
{
    sealed class URLShortener
    {
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string PATTERNREGEX = @"(\b(http|https):\/{2}\w(((\w|\.|-){1,})|(\.\w{2,3}))\/)";

        public static string URLShortening(int idURL)
        {
            string shortUrl = "";

            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                int curChr = (rand.Next(0, ALPHABET.Length) + idURL) % ALPHABET.Length;
                shortUrl += ALPHABET[curChr];
            }

            return shortUrl;
        }

        public static string URLDomCuter(string fullUrl)
        {
            Regex urlDom = new Regex(PATTERNREGEX);
            Match match = urlDom.Match(fullUrl);
            if (match.Success)
                return match.Groups[1].Value;

            return "";
        }

        public static string URLReplacer(string oldUrl, string newUrl)
        {
            string url = Regex.Replace(oldUrl, PATTERNREGEX, URLDomCuter(newUrl));

            return url;
        }
    }
}
