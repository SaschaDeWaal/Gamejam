using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player"){
			Rigidbody body = GetComponent<Rigidbody>();
			body.AddForce((transform.position-col.transform.position+new Vector3(0,10,0))*200);
		}
	}
}
