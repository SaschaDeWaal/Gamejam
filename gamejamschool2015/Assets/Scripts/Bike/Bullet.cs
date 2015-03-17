using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	void start()
	{
		Destroy (gameObject, 3.0f);
	}

	void Update()
	{
		transform.Translate (new Vector3(0,0,1.0f));
	}
}
