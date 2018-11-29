using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyClick : MonoBehaviour {

    private GameObject character;
    private Renderer rend;
    [SerializeField]
    private Color pressedColor;
    [SerializeField]
    public KeyCode _key;   

    // Use this for initialization
    void Start () {
        character = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(_key))
        {
            //Click the button
            rend.material.color = pressedColor;
            character.GetComponent<CharacterMovement>().MoveCharacterTo(transform.position); //hacer que el player se mueva a la posicion de la "tecla"
        }
        else if (Input.GetKeyUp(_key))
        {
            rend.material.color = Color.white;
        }

    }

}
