using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public HUD hud;
	private bool hit; 
	
	void OnCollisionEnter(Collision col)
	{
		if(hit == true) return;
	
		/*if (col.gameObject.tag == "Player")
		{
			if(!col.gameObject.GetComponent<PlayerControll>().Moving) return;
			
			Rigidbody body = GetComponent<Rigidbody>();
			hud.AddScore(10);
			hit = true;
			body.AddForce((transform.position-col.transform.position+new Vector3((Random.value - 0.5f) * 4,50,0))*200);
			Destroy(gameObject,  3.0f);
		}*/
		
		if(col.gameObject.tag == "Bullet")
		{
			Rigidbody body = GetComponent<Rigidbody>();
			hud.AddScore(10);
			hit = true;
			body.AddForce((transform.position-col.transform.position+new Vector3((Random.value - 0.5f) * 4,50,0))*200);
			Destroy(gameObject,  0.5f);
		}
	}
}
