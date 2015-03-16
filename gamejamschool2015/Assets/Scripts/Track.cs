using UnityEngine;
using System.Collections;

public class Track
{
	private static Vector3[] waypoints = new Vector3[]{
		new Vector3(0,0,0), new Vector3(4,0,4), new Vector3(0,0,8)
	};
	
	/****class methods****/
	public static Vector3 GetNewWaypoint(int index)
	{
		return waypoints[index % waypoints.Length];
	}
}
