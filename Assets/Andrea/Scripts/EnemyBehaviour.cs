using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        MoveEnemy();

    }

    void MoveEnemy()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

    }
}
