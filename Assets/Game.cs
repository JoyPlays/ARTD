using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	private GameObject levelAR;
	[SerializeField]
	private Transform worldTransform;

	private void Update()
	{
	}

	public void MoveToWorld()
	{
		Debug.Log("World Transform Moved!");
		levelAR.transform.parent = worldTransform;
	}

}
