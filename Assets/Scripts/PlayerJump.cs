using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public float Force = 100f;
	public float MaxAngle = 20f;
	public float MaxVelocity = 30f;

	Rigidbody rig;
	bool isAdd = false;		//判断是否在brid速度为向下时已添加向下速度
	GameControler gc;
	int count = 0;	//帽子个数计数
	float size = 1f;	//帽子尺寸
	bool isBegin = false;//判断游戏是否开始
	
	void Start () {
		rig = GetComponent<Rigidbody>();
		gc = GameObject.Find("GameControler").GetComponent<GameControler>();
	}
	

	void FixedUpdate () {
		Jump();
		RotateBody();
		isDeath();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag != null && other.tag == "Gold"){
			other.gameObject.tag = "null";
			++count;
			Debug.Log("Count = " + count);
			other.transform.position = transform.position + transform.up * count * size;
			other.transform.parent = transform;
			other.GetComponent<AutoMovement>().enabled = false;
			other.GetComponent<GoldRotate>().enabled = false;
			other.gameObject.transform.rotation = Quaternion.identity;
			
		}
	}

	//跳
	void Jump(){

		if(Input.GetButtonDown("Jump")){
			if(!isBegin){
				gc.GameBegin();//	开始游戏UI操作
				rig.isKinematic = false;	//解除运动学状态，让brid可以移动
				isBegin = true;
			}
			isAdd = false;
			rig.velocity = Vector3.up * 30;
		}
		if(rig.velocity.y < 0 && !isAdd){
			rig.velocity = Vector3.down * 5;	//添加向下初速度
			isAdd = true;
		}
		if(Mathf.Abs(rig.velocity.y) > MaxVelocity){
			rig.velocity = Vector3.down * MaxVelocity;
			// Debug.Log("Jup");
		}
	}
	//身体倾
	void RotateBody(){
		//速度>0向上倾, 速度<0向下倾
		float angle = Mathf.Clamp(rig.velocity.y, -MaxAngle, MaxAngle);
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
	//判断是否越界死亡
	void isDeath(){
		if(transform.position.y > 78 || transform.position.y < 13){
			gc.GameOver();
			this.enabled = false;
		}
	}
}
