using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Klingon
{
	public class Translator:ITranslator
	{ /// <summary>
	 /// Provides the data associated to klingon alphabeth
	 /// </summary>
	 /// <returns></returns>
		public string[,]  GetAlphabeth()
		{
			var kalpha = new string[,] { { "a", "F8D0" }, { "b", "F8D1" }, { "ch", "F8D2" }, { "D", "F8D3" }, { "e", "F8D4" }, { "gh", "F8D5" }, { "h", "F8D6" }, { "I", "F8D7" }, { "j", "F8D8" }, { "l", "F8D9" }, { "m", "F8DA" }, { "n", "F8DB" }, { "ng", "F8DC" }, { "o", "F8DD" }, { "p", "F8DE" }, { "q", "F8DF" }, { "Q", "F8E0" }, { "r", "F8E1" }, { "S", "F8E2" }, { "t", "F8E3" }, { "tlh", "F8E4" }, { "u", "F8E5" }, { "v", "F8E6" }, { "w", "F8E7" }, { "y", "F8E8" }, { "'", "F8E9" }, { "1", "F8F1" }, { "2", "F8F2" }, { "3", "F8F9" }, { "4", "F8F4" }, { "5", "F8F5" }, { "6", "F8F6" }, { "7", "F8F7" }, { "8", "F8F8" }, { "9", "F8F9" }, { "0", "F8F0" }, { ".", "F8FD" }, { ",", "F8FE" }, { " ", "0020" } };
			return kalpha;
		}
		/// <summary>
		/// if arguments comes in Capitalized turn into lowercase
		/// </summary>
		/// <returns></returns>
		public string LowercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			return char.ToLower(s[0]) + s.Substring(1);
		}
		/// <summary>
		/// Translator English Klingon
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public  string Translate(string word)
		{
			word = LowercaseFirst(word);
			var response = "";
			string[,] Hexarr = GetAlphabeth();
			int p = 0;
			string strrepl = "";
			int f = -1;
			string w;
			while (p < word.Length)
			{
				w = word[p].ToString();
				
				f = findwordpos(Hexarr, w);
				if (f > -1)
				{
					strrepl = "0x" + Hexarr[f, 1];
					response = response + " " + strrepl;
				}
				p++;
			}
			
			return response;
		}
		/// <summary>
		/// find word index inside a provided array
		/// </summary>
		/// <param name="array"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		public int findwordpos(string[,] array, string w)
		{
			int resp = -1;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				if (w == array[i, 0])
				{
					resp = i;
				
				}
			}
			return resp;
		}
		/// <summary>
		/// get first specie related to a name
		/// </summary>
		/// <param name="url"></param>
		public  void getSpecie(string url)
		{
			var data = getrequest(url, 1);
			foreach (Result d in data.results)
			{
				foreach (var e in d.species)
				{
					data = getrequest(e.ToString(), 2);
				
				}
			}
			
			if (data.ToString() == "Klingon.RootObject")
				ErrorDisplay("Not Found Data related provided name");
			else
				Console.WriteLine(data.name.ToString());
		}
		/// <summary>
		/// Display a error message in console
		/// </summary>
		/// <param name="v"></param>
		public  void ErrorDisplay(string v)
		{
			Console.WriteLine(v);
		}
		/// <summary>
		/// Make WeB API Request
		/// </summary>
		/// <param name="url"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public  dynamic getrequest(string url, int value)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = client.GetAsync(url).Result;
			var json = response.Content.ReadAsStringAsync().Result;
			dynamic data = null;
			switch (value)
			{
				case 1:
					data = JsonConvert.DeserializeObject<RootObject>(json);
					break;
				case 2:
					data = JsonConvert.DeserializeObject<Result>(json);
					break;
			}

			return data;
		}
	}
}


