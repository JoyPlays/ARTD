using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private WaypointManager wpManager;
 
	[SerializeField] private GameObject enemyType;
	[SerializeField] private int enemiesToSpawn = 10;
	[SerializeField] private int enemiesSpawned = 0;



	public void EnemySpawner()
	{
		StartCoroutine(SpawnEnemy(enemyType));
	}

	IEnumerator SpawnEnemy(GameObject enemy)
	{
		while (enemiesSpawned < enemiesToSpawn)
		{
			Instantiate(enemy, wpManager.waypoints[0].position, Quaternion.identity);
			enemiesSpawned++;
			yield return new WaitForSeconds(2f);
		}
		
	}

}
