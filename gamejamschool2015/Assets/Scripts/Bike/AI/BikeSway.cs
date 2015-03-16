using UnityEngine;
using System.Collections;

public class BikeSway : MonoBehaviour 
{	
	void Update () 
	{
		transform.localEulerAngles = new Vector3 (
			Mathf.Cos(Time.time * 5.0f) * 20.0f, 
			transform.localEulerAngles.y,
			0
		);	
	}
}
