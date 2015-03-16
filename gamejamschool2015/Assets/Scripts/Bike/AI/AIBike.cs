using UnityEngine;
using System.Collections;

public class AIBike : MonoBehaviour
{
	public float maxSpeed;
	public float maxSteering;
	private Vector3 velocity;
	private Vector3 target;
	private Vector3 steering;
	private int progress = 0;
	private Transform child;
	private Rigidbody rigidbody;

	void Start()
	{
		child = transform.GetChild(0);
		rigidbody = GetComponent<Rigidbody> ();
		target = Track.GetNewWaypoint(progress++);
		velocity = (target - transform.position).normalized * maxSpeed;
	}

	void Update()
	{
		Vector3 desired_velocity = (target - transform.position).normalized * maxSpeed;
		steering = desired_velocity - steering;

		if (steering.magnitude > maxSteering)
			steering = steering.normalized * maxSteering;
		
		velocity += steering;
			
		if(velocity.magnitude > maxSpeed)
			velocity = velocity.normalized * maxSpeed;

		if (Vector3.Distance (target, transform.position) < 2.0f)
			target = Track.GetNewWaypoint (progress++);
		
		child.forward = new Vector3(
			velocity.normalized.x,
			0,
			velocity.normalized.z
		); //velocity.normalized;
	}

	void FixedUpdate()
	{
		rigidbody.position += velocity;
	}
}

/*
public class oudAIBike : MonoBehaviour 
{
	public float minDistance = 2.0f;
	public float accelaration;
	
	private float maxSpeed = 22.0f;
	private int progress = 0;
	private Vector3 currentWaypoint;
	private bool alive = true;
	private float direction;
	private float targetAngle;
	
	private Rigidbody rigidbody;
	
	/****unity methods***
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
			//print (angle);

			SteerTo(angle);
			transform.eulerAngles = new Vector3(
				0,
				direction,
				0
			);
			//transform.forward = Vector3.RotateTowards(transform.forward, currentWaypoint - transform.position, Time.deltaTime * 2, 80.0f);
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
	
	/****class methods***
	private float GetAngle(Vector3 other)
	{
		return Mathf.Rad2Deg * Mathf.Atan2(other.x - transform.position.x, other.z - transform.position.z);
	}

	protected void SteerTo(float target)
	{
		float angle = target - direction;
		while(angle < -180) angle += 360;
		while (angle > 180) angle -= 360;

		direction += Mathf.Min(rigidbody.velocity.magnitude * (maxSpeed / 500), Mathf.Abs(angle)) * Mathf.Sign(angle);//Mathf.Sign (angle);//Mathf.Clamp (angle, -1, 1);//
	}
}*/