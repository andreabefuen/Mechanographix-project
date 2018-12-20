using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;

    private bool stop = false;

    private GameBehaviour gameManager;

    Animator anim;

	// Use this for initialization
	void Start () {
        transform.Rotate(0, -90, 0);

        anim = this.gameObject.GetComponent<Animator>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        if(stop == false)
        {
            MoveEnemy();

        }

        if (transform.position.x < -5f && stop == false)
        {
            //Daño
            GameBehaviour.Score -= 200;
            stop = true;
            anim.SetBool("isAttack", true);
            gameManager.DamagePanelActivate();
            //this.gameManager.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject, 1.5f);
        }

    }

    void MoveEnemy()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
