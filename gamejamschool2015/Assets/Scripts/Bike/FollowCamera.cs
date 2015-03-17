using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject player;
	GameObject pointer;
	const float maxDistance = 9;
	const float minDistance = 5;
	const float abovePlayer = 12;
	private float speed = 0;
	private float shakeTimer = 0.4f;
	private bool shake;

	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player");
		pointer = transform.GetChild(0).gameObject;
	}

	void Update () {

		//look to the player
		transform.LookAt(player.transform);

		//move to player
		//transform.forward = Vector3.Lerp(transform.forward, player.transform.forward - new Vector3(0, 0.3f, 0), Time.deltaTime * 4.0f);
		transform.forward += new Vector3 (0,0.5f,0);
		transform.position = player.transform.position - (player.transform.rotation * new Vector3(0, -abovePlayer, minDistance));

		if (shake) {
			shakeTimer-= Time.deltaTime;
			transform.forward += new Vector3 ((Random.value - 0.5f) * 0.035f, (Random.value - 0.5f) * 0.035f, (Random.value - 0.5f) * 0.035f);
			if(shakeTimer <= 0)
				shake = false;
		}


		/*Vector2 camPos = new Vector2(transform.position.x,transform.position.z);
		Vector2 playerPos = new Vector2(player.transform.position.x,player.transform.position.z);

		float dis = Vector3.Distance(camPos,playerPos);
		
		if (dis > maxDistance)
		{
			if (speed < 1) speed += Time.deltaTime*2.0f;
		}
		/*else if (dis < minDistance)
		{
			if (speed > -1f) 
				speed -= Time.deltaTime*1.5f;
		}
		else
		{
			speed = Mathf.Lerp(speed, 0, Time.deltaTime * 5.0f);
			/*if (speed > 0f) 
				speed -= Time.deltaTime*2.0f;
		}
		
		transform.Translate(Vector3.forward*speed*Time.deltaTime*20);
		transform.position = new Vector3(transform.position.x,player.transform.position.y+abovePlayer,transform.position.z);*/
	}

	public void shakeCam()
	{
		shake = true;
		shakeTimer = 0.1f;
	}
}
