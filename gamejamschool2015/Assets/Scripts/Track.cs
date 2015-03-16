using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour
{
	private static Transform[] waypoints;
	/*private static Vector3[] waypoints = new Vector3[]{
		new Vector3(52.12f, 0, 0), new Vector3(28.2f, 0, 162.4f), new Vector3(11f,0,191.1f), new Vector3(-44.3f,0,191.2f),
		/*new Vector3(-93.6f, 0, 91.0f), new Vector3(-169.8f, 0, -74.1f), new Vector3(-154.8f, 0, -105.0f), new Vector3(-99.0f, 0, -126.9f),
		new Vector3(-25.7f, 0, -84.7f), new Vector3(49.7f, 0, -69.92f), new Vector3(56.25f, 0, -62.15f)
	};*/

	void Start()
	{
		waypoints = gameObject.GetComponentsInChildren<Transform> ();
	}

	/****class methods****/
	public static Vector3 GetNewWaypoint(int index)
	{
		if (waypoints == null)
			return new Vector3 (-10, 0, 0);//Vector3.zero;
		
		return waypoints[index % waypoints.Length].position;
	}
}
