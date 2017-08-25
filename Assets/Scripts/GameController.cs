/*
 * GameContoller.cs
 * 
 * Create by WRF
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public List<GameObject> buttonList;

    public GameObject confirmExitWindow;
    public GameObject confirmRestartWindow; 

    UILabel score;
    bool isPause = false;

    void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<UILabel>();

        InitButton();
    }

    void InitButton(){
        foreach(GameObject item in buttonList){
            switch(item.name){
                //暂停按钮
                case R.BTN_PAUSE:    
                    InitPauseBtn(item);
                    break;

                case R.BTN_EXIT:
                    //退出按钮
                    InitExitBtn(item);
                    break;

                case R.EXIT_YES:
                    ExitYes(item);
                    break;
                    
                case R.EXIT_NO:
                    ExitNo(item);
                    break;

                case R.RESTART_YES:
                    RestartYes(item);
                    break;
                
                case R.RESTART_NO:
                    RestartNo(item);
                    break;
            }
        }
    }
    //暂停按钮响应事件
    void InitPauseBtn(GameObject item){
        UIEventListener.Get(item).onClick = go => {
            isPause = !isPause;
            Time.timeScale = isPause ? 0 : 1;   //暂停逻辑
            item.GetComponent<UIButton>().normalSprite = isPause ? R.PAUSE_NORMAL : R.PLAY_NORMAL;
            item.GetComponent<UIButton>().pressedSprite = isPause ? R.PLAY_PRESSED : R.PLAY_PRESSED;
        };
    }
    //退出按钮响应事件，调出confirm窗口
    void InitExitBtn(GameObject item){
        UIEventListener.Get(item).onClick = go =>{
            confirmExitWindow.SetActive(true);
        };
    }
    //确认退出
    void ExitYes(GameObject item){
        UIEventListener.Get(item).onClick = go => {
            Application.Quit();
        };
    }

    //取消退出
    void ExitNo(GameObject item){
        UIEventListener.Get(item).onClick = go =>{
            confirmExitWindow.SetActive(false);
        };
    }

    //确认重新开始
    void RestartYes(GameObject item){
        UIEventListener.Get(item).onClick = go =>{
            Application.LoadLevel(Application.loadedLevel);
        };
    }
    //取消重新开始
    void RestartNo(GameObject item){
        UIEventListener.Get(item).onClick = go =>{
            confirmRestartWindow.SetActive(false);
            confirmExitWindow.SetActive(true);
        };
    }

    //添加分数
    public void AddScore(){
        score.text = (int.Parse(score.text) + 1).ToString();
        Debug.Log(score.text);
    }
    //游戏结束
    public void GameOver(){
        confirmRestartWindow.SetActive(true);
    }

	
}

/**
*　　　　　　　　┏┓　　　┏┓+ +
*　　　　　　　┏┛┻━━━┛┻┓ + +
*　　　　　　　┃　　　　　　　┃ 　
*　　　　　　　┃　　　━　　　┃ ++ + + +
*　　　　　　 ████━█████+
*　　　　　　　┃　　　　　　　┃ +
*　　　　　　　┃　　　┻　　　┃
*　　　　　　　┃　　　　　　　┃ + +
*　　　　　　　┗━┓　　　┏━┛
*　　　　　　　　　┃　　　┃　　　　　　　　　　　
*　　　　　　　　　┃　　　┃ + + + +
*　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
*　　　　　　　　　┃　　　┃ + 　　　　神兽保佑,代码无bug　　
*　　　　　　　　　┃　　　┃
*　　　　　　　　　┃　　　┃　　+　　　　　　　　　
*　　　　　　　　　┃　 　　┗━━━┓ + +
*　　　　　　　　　┃ 　　　　　　　┣┓
*　　　　　　　　　┃ 　　　　　　　┏┛
*　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
*　　　　　　　　　　┃┫┫　┃┫┫
*　　　　　　　　　　┗┻┛　┗┻┛+ + + +
*/
