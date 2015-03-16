using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour
{
	private static Vector3[] waypoints = new Vector3[]{
		new Vector3(52.12f, 0, 0), new Vector3(24.8f, 0, 162.4f), new Vector3(12.3f,0,193.1f), new Vector3(-48.9f,0,190.2f),
		new Vector3(-93.6f, 0, 91.0f), new Vector3(-163.2f, 0, -74.3f), new Vector3(-154.8f, 0, -105.0f), new Vector3(-96.4f, 0, -127.0f),
		new Vector3(-26.8f, 0, -87.7f), new Vector3(63.5f, 0, -66.5f)
	};

	/****class methods****/
	public static Vector3 GetNewWaypoint(int index)
	{
		return waypoints[index % waypoints.Length];
	}
}
