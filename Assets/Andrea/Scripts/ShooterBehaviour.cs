using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour {

    public GameObject bala;

    public Transform positionDisparo;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shot()
    {
        GameObject aux = Instantiate(bala);
        aux.transform.position = positionDisparo.position;
        Debug.Log(positionDisparo.transform.position);
        RaycastHit raycastHit;
        
       // if(Physics.Raycast(transform.position, transform.forward, out raycastHit))
       // {
       //     if(raycastHit.transform.tag == "Enemy")
       //     {
       //         Debug.Log("Le has dado");
       //         Destroy (raycastHit.collider.gameObject, 1.5f);
       //         GameBehaviour.Score += 100;
       //         
       //     }
       // }

        //Debug.Log("PIUM");

        //Debug.DrawRay(transform.position, transform.forward, Color.red);

    }
}
