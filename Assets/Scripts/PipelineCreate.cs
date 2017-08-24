using UnityEngine;
using System.Collections;

public class PipelineCreate : MonoBehaviour {

	public GameObject Pinpeline;
	public GameObject Gold;

	private float interval = 2f;	//管子产生的间隔时间
	private float timer = 2f;		//计时器

	private Vector3 upPosition;
	private Vector3 downPosition;
	private Vector3 goldPosition;
	private float moveRange = 25f;
	private float downMin = 25f;
	private float downMax = 40f;

	void Start () {
		
	}
	
	void Update () {
		timer += Time.deltaTime;
		if(timer > interval){
			timer = 0f;
			
			upPosition = transform.position;
			upPosition.y += Random.Range(0,moveRange);
			Instantiate(Pinpeline, upPosition, Quaternion.identity);

			downPosition = upPosition;
			downPosition.y -= 20f + Random.Range(downMin, downMax);
			Instantiate(Pinpeline, downPosition, Quaternion.Euler(180f, 0, 0));

			
			Instantiate(Gold, (upPosition + downPosition)/2, Quaternion.identity);
		}
	}
	
}
