using UnityEngine;
using System.Collections;

public class PipelineTrigger : MonoBehaviour {
	
	GameController gc;
	GameObject brid;

	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		brid = GameObject.FindWithTag("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			// Debug.Log("Trigger");
			gc.GameOver();			//结束页面
			brid.GetComponent<PlayerJump>().enabled = false;//brid不能控值

			
		}
	}
}
