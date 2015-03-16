using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	GameObject player;
	GameObject pointer;
	const float maxDistance = 8;
	const float minDistance = 3;
	const float abovePlayer = 4;
	private float speed = 0;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pointer = transform.GetChild(0).gameObject;
	}
	

	void Update () {

		//look to the player
		transform.LookAt(player.transform);


		//move to player
		Vector2 camPos = new Vector2(transform.position.x,transform.position.z);
		Vector2 playerPos = new Vector2(player.transform.position.x,player.transform.position.z);

		float dis = Vector3.Distance(camPos,playerPos);
		if (dis > maxDistance){
			if (speed < 1) speed += Time.deltaTime*1.5f;
		}else if (dis < minDistance){
			if (speed > -1f) speed -= Time.deltaTime*1.5f;
		}else{
			if (speed > 0f) speed -= Time.deltaTime*1.5f;
		}
		transform.Translate(Vector3.forward*speed*Time.deltaTime*5);
		transform.position = new Vector3(transform.position.x,player.transform.position.y+abovePlayer,transform.position.z);
	}
}
