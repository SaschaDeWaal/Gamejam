using UnityEngine;
using System.Collections;

public class AIBike : MonoBehaviour 
{
	public float minDistance = 2.0f;
	public float accelaration;
	
	private float maxSpeed = 5.0f;
	private int progress = 0;
	private Vector3 currentWaypoint;
	private bool alive = true;
	private float direction;
	private float targetAngle;
	
	private Rigidbody rigidbody;
	
	/****unity methods****/
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody>();
		currentWaypoint = Track.GetNewWaypoint(progress++);
	}
	
	void Update () 
	{
		if (alive)
		{
			Debug.DrawLine(transform.position, currentWaypoint);
			//calculate steering
			float angle = GetAngle(currentWaypoint); 
			if(angle > 5.0f)
			{
				/*SteerTo(angle);
				transform.eulerAngles = new Vector3(
					0,
					direction,
					0
				);*/
				//steerForce =  RotateTo(transform.eulerAngles.y, angle) * 80.0f;
				//transform.forward = Vector3.Lerp(transform.forward, -(transform.position - currentWaypoint), Time.deltaTime / 2);
				transform.forward = Vector3.RotateTowards(transform.forward, currentWaypoint - transform.position, Time.deltaTime * 2, 80.0f);
			}
			//check distance
			if(Vector3.Distance(currentWaypoint, transform.position) < minDistance)
				currentWaypoint = Track.GetNewWaypoint(progress++);				
		}
	}
	
	void FixedUpdate()	
	{
		if (alive)
		{
			// add physics forces
			if(rigidbody.velocity.magnitude < maxSpeed)
			{
				rigidbody.AddRelativeForce(
					new Vector3(0,0, accelaration) * rigidbody.mass
				);
			}				
		}
	}
	
	/****class methods****/
	private float GetAngle(Vector3 other)
	{
		float angle = (currentWaypoint - transform.position);
		return angle;
	}

	protected void SteerTo(float target)
	{
		print (target);
		float angle = (float)(target - direction);
		while(angle < -Mathf.PI) angle += (float)Mathf.PI*2;
		while (angle > Mathf.PI) angle -= (float)Mathf.PI*2;
		
		direction += (float)Mathf.Min(rigidbody.velocity.magnitude * maxSpeed, Mathf.Abs(angle)) * Mathf.Sign(angle);
	}
}