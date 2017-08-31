using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Klingon
{
	class Program
	{
		/// <summary>
		/// Written by: Hugo Araujo R.
		/// Exercise Stark Trek Klingon Translator
		/// "https://drive.google.com/file/d/0B_vik24TEEkCNnF3VWw2c1NLZTA/view"
		/// </summary>
		/// <param name="args"></param>
		/// 
		static void Main(string[] args)
		{
			string url = "https://swapi.co/api/people/?search=";
			var aux = new Translator();
			
			if (args.Length == 0)
				aux.ErrorDisplay("No name Provided");
			else
			{
				var word = args[0];
				string result = "";
				int n = args.GetUpperBound(0);
				int i = 0;
				foreach (string w in args)
				{
					result+=aux.Translate(w);
					i++;
					if (i <= n)
						result += " 0x0020";
				}
				//Print Out Result
				Console.WriteLine(result); 
				aux.getSpecie(url +word);
			}
			
			Console.ReadKey();
		}
	

	}
}


