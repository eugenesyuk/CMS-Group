using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DB.Extensions {
	public static class Extensions {
		public static string ToSHA1Hash(this string str) {
			return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
		}

		public static string GetURL(this string url) {
			url = url.ToLower();
			var map = new Dictionary<char, string>
			{
				{ 'а', "a" },
			    { 'б', "b" },
				{ 'в', "v" },
				{ 'г', "h" },
				{ 'ґ', "g" },
				{ 'д', "d" },
				{ 'е', "e" },
				{ 'э', "ie" },
				{ 'є', "ie" },
				{ 'ж', "zh" },
				{ 'з', "z" },
				{ 'и', "y" },
				{ 'і', "i" },
				{ 'ї', "i" },
				{ 'й', "i" },
				{ 'к', "k" },
				{ 'л', "l" },
				{ 'м', "m" },
				{ 'н', "n" },
				{ 'о', "o" },
				{ 'п', "p" },
				{ 'р', "r" },
				{ 'с', "s" },
				{ 'т', "t" },
				{ 'у', "u" },
				{ 'ф', "f" },
				{ 'х', "kh" },
				{ 'ц', "ts" },
				{ 'ч', "ch" },
				{ 'ш', "sh" },
				{ 'щ', "shch" },
				{ 'ю', "iu" },
				{ 'я', "ia" },
				{ 'ь', "" },
				{ 'ъ', "" },
				{ 'ы', "y" },
				{ ' ', "-" }
			};
			return string.Concat(url.Select(c => map[c]));
		}
	}
}
