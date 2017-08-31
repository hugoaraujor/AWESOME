namespace Klingon
{
	public interface ITranslator
		{ 
		//Get Klingon Alphabeth
		string[,] GetAlphabeth();
	 	//in case the word provided comes Capitalized get the word in lowercase
	 	string LowercaseFirst(string s);
		//Main function Translate word
		string Translate(string word);
			int findwordpos(string[,] array, string w);
		//Get Specie related name provided
		void getSpecie(string url);
		//Display an error Message in console
		void ErrorDisplay(string v);
		//Get request from Web Api
		dynamic getrequest(string url, int value);
		}

}
