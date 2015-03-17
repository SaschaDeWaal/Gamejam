using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	const float maxSpeed = 20;
	public Transform gunBarrel;
	public ParticleSystem[] muzzle;
	public FollowCamera cam;

	private static bool upgrade;	
	public bool Moving{
		get{return Mathf.Abs(Input.GetAxis("Vertical")) == 1;}
	}
	public bool Guns{
		get{return false;}
	}
	
	void Update () {
		control();
		transform.eulerAngles = new Vector3(
			0,
			transform.eulerAngles.y
			,0
		);
		
		if (Input.GetButtonDown ("Jump"))
			Shoot ();
	}

	void Shoot()
	{
		muzzle[0].Play ();
		muzzle[1].Play ();
		cam.shakeCam ();
		GameObject bullet = Instantiate (Resources.Load ("Bullet"), gunBarrel.position, Quaternion.identity) as GameObject;
		bullet.transform.forward = gunBarrel.forward;
	}
	
	void control()
	{
		transform.Translate(Vector3.forward*Time.deltaTime*maxSpeed*Input.GetAxis("Vertical"));
		if (Input.GetAxis("Vertical") != 0f){
			transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal") * Input.GetAxis("Vertical") * 1.2f,0));
		}
	}
	
	public static void ToggleGun()
	{
		print ("gun");
		upgrade = true;
	}
}
