﻿using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour
{
	private static Transform[] waypoints;

	void Start()
	{
		waypoints = GetComponentsInChildren<Transform> ();
	}

	/****class methods****/
	public static Vector3 GetNewWaypoint(int index)
	{
		if (waypoints == null) return Vector3.zero;
		return waypoints[index % waypoints.Length].position;
	}
}
