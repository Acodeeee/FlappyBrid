using UnityEngine;
using System.Collections;

public class PipelineRemove : MonoBehaviour {

	
	private GameControler gc;	//Score脚本对象
	private Transform brid;
	private bool isAdd = false;	//是否已经添加分数

	void Start () {
		gc = GameObject.Find("GameControler").GetComponent<GameControler>();
		brid = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
		
		AddScore();
	}
	
	//添加分数
	void AddScore(){
		if(transform.position.x < brid.position.x && !isAdd){
			isAdd = true;
			// Debug.Log("AddScore P");
			gc.AddScore();
		}
	}
}
