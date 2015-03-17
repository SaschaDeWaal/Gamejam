using UnityEngine;
using System.Collections;

public class BikeDancing : MonoBehaviour 
{	
	public float danceAmount;
	private int startTime;
	
	
	void Start()
	{
		startTime = (int)Mathf.Round(Time.time-(Random.value * 20)); 
	}
	
	void Update () 
	{
		transform.localEulerAngles = new Vector3 (
			Mathf.Cos((Time.time - startTime) * 5.0f) * danceAmount, 
			transform.localEulerAngles.y,
			0
		);	
	}
}
