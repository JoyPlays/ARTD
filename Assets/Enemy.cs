using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private WaypointManager wpManager;
	[SerializeField] private float minimumDistance = 2f;
	[SerializeField] private float enemySpeed = 5f;

	[SerializeField] private Animator animator;

	private float timeElapsed = 0f;
	private bool flag = false;

	private void Start()
	{
		wpManager = FindObjectOfType<WaypointManager>();
		animator = GetComponentInChildren<Animator>();
		animator.SetBool("Static_b", true);
		animator.SetFloat("Speed_f", 1);
		StartCoroutine(MoveAlongWaypoints(wpManager));
	}

	IEnumerator MoveAlongWaypoints(WaypointManager wpManager)
	{
		foreach(Transform waypoint in wpManager.waypoints)
		{
			Vector3 currentPosition = gameObject.transform.position;
			while(Vector3.Distance(transform.position, waypoint.transform.position) > 0.5f)
			{
				if(timeElapsed < enemySpeed)
				{
					gameObject.transform.position = Vector3.Lerp(currentPosition, waypoint.position, timeElapsed / enemySpeed);
					gameObject.transform.LookAt(waypoint);
					timeElapsed += Time.deltaTime;
				}
				yield return null;
			}
			timeElapsed = 0f;
		}
	}
}
