using UnityEngine;
using System.Collections;

public class GoldRotate : MonoBehaviour {

	GameController gc;
	bool isAdd = false;
	Rigidbody rig;

	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		rig = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		transform.Rotate(10f, 0, 0);
		if(transform.position.y < 15){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//碰撞者是子弹
		if(other.tag == "Bullet" && !isAdd){
			isAdd = true;
			rig.isKinematic = false;
			rig.AddForce(Vector3.left * 100);
			gc.AddScore();
			Destroy(other.gameObject);
		}
	}
}
