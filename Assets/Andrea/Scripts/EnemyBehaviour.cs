﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    

	// Use this for initialization
	void Start () {
        transform.Rotate(0, -90, 0);
	}
	
	// Update is called once per frame
	void Update () {

        MoveEnemy();

        if (transform.position.x < -12f)
        {
            //Daño
            GameBehaviour.Score -= 200;
            Destroy(this.gameObject);
        }

    }

    void MoveEnemy()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
