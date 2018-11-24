using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    [SerializeField]
    private Transform[] spawnPoints;

    public float spawnTime;

    public GameObject enemy;

	// Use this for initialization
	void Start () {

        enemy.SetActive(true);
        InvokeRepeating("SpawnTheEnemy", 2.5f, spawnTime);



    }

    // Update is called once per frame
    void Update () {

        

    }

    
    void SpawnTheEnemy()
    {

        Transform aux = GetRandomPoint();

        Instantiate(enemy, aux.position, Quaternion.identity);

    }


    Transform GetRandomPoint()
    {

        Debug.Log("Random");
        int aux = Random.Range(0, spawnPoints.Length);

        Transform spawn = spawnPoints[aux];

        return spawn;
    }
}
