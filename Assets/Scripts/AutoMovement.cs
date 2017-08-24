using UnityEngine;
using System.Collections;

public class AutoMovement : MonoBehaviour {

	public float speed = 10f;
	private float removeLine = -75f;	//越线移除位置

	void FixedUpdate () {
		Move();
		Remove();
	}
	//移动
	void Move(){
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
	//越界删除
	void Remove(){
		if(transform.position.x < removeLine){
			Destroy(gameObject);
		}
	}
	

}
