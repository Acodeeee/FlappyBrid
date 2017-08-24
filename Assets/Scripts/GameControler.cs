using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

	public Text ScoreText;
	public Text OverText;
	public Text BeginText;

	int score = 0; 
	bool isGameOver = false;

	//游戏开始，关闭提升显示
	public void GameBegin(){
		BeginText.enabled = false;
	}
	
	//加分数
	public void AddScore(){
		score += 1;
		ScoreText.text = "Score:" + score;
		// Debug.Log("Score");
	}
	//游戏结束
	public void GameOver(){

		// Debug.Log(ScoreText.text);
		int intScore = int.Parse(ScoreText.text.Substring(6, ScoreText.text.Length - 6));//截取分数
		string evaluate = intScore + "分";
		if(intScore < 5){
			evaluate += "菜鸡";
		}else if(intScore >=5 && intScore < 10){
			evaluate += "老菜鸡";
		}else if(intScore >=10){
			evaluate += "大神";
		}
		//当前分数为最高分，存储到txt
		if(intScore > ReadTxt.GetMaxScore()){
			ReadTxt.SetMaxScore(intScore);
			evaluate += "\n新的最高分！";
		}else{
			evaluate += "\n最高分为：" + ReadTxt.GetMaxScore();
		}

		//游戏结束UI显示
		OverText.text = "Game Over !\n" + evaluate + "\n按 R 键重新开始游戏";		
		ScoreText.enabled = false;	//移除左上角分数

		

		isGameOver = true;
	}
	void Update()
	{
		if(isGameOver && Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
