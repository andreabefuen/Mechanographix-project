using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shot()
    {
        RaycastHit raycastHit;
        
        if(Physics.Raycast(transform.position, transform.right, out raycastHit))
        {
            if(raycastHit.transform.tag == "Enemy")
            {
                Debug.Log("Le has dado");
                Destroy (raycastHit.collider.gameObject, 0.5f);
                GameBehaviour.Score += 100;
                
            }
        }

        //Debug.Log("PIUM");

        //Debug.DrawRay(transform.position, transform.forward, Color.red);

    }
}
