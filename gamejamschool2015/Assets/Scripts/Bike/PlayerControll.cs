using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	const float maxSpeed = 5;
	
	void Update () {
		control();
	}

	void control(){
		transform.Translate(Vector3.forward*Time.deltaTime*maxSpeed*Input.GetAxis("Vertical"));
		if (Input.GetAxis("Vertical") != 0f){
			transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0));
		}
	}
}
