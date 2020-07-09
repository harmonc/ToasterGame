using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
	public GameObject enemy;
    public GameObject enemy2;



	private float targetTime = 0.0f;
	// Use this for initialization
	void Start () {
		
	}

	void Update(){

		targetTime -= Time.deltaTime;

		if (targetTime <= 0.0f)
		{
			SpawnEnemy();
			targetTime = 1.5f;
		}
    }


	void SpawnEnemy()
	{
        GameObject enemyToSpawn;
        if (Random.Range(0.0f, 1.0f) >= 0.5f)
        {
            enemyToSpawn = enemy;
        }
        else
        {
            enemyToSpawn = enemy2;
        }


		GameObject e = Instantiate (enemyToSpawn, new Vector3 (Random.Range (-3.0f, 3.0f), 7, 1), transform.rotation);
        e.SetActive(true);
	}

}
