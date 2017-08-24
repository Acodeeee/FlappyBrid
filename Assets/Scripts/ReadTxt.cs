using System;
using System.IO;


public class ReadTxt{
	public static readonly string PATH = "score.txt";

	public static void SetMaxScore(int maxScore){
		FileStream file = File.Open(PATH, FileMode.OpenOrCreate);

		StreamWriter writer = new StreamWriter(file);

		writer.WriteLine(maxScore);

		writer.Flush();

		writer.Close();
		file.Close();
		
	}

	public static int GetMaxScore(){
		int score = 0;
		StreamReader reader;
		try{
			reader = new StreamReader(PATH);
		}
		catch{
			return 0;
		}
		score = int.Parse(reader.ReadLine());
		reader.Close();
		return score;
	}
}
