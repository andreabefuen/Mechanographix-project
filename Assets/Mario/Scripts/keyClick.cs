using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyClick : MonoBehaviour {

    private GameObject character;
    private Renderer rend;
    [SerializeField]
    private Color KeyColor;
    [SerializeField]
    public KeyCode _key;

    // Use this for initialization
    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = KeyColor;
        character = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(_key))
        {
            //Click the button
            rend.material.color = Color.black;
            character.GetComponent<CharacterMovement>().MoveCharacterTo(transform.position); //hacer que el player se mueva a la posicion de la "tecla"
        }
        else if (Input.GetKeyUp(_key))
        {
            rend.material.color = KeyColor;
        }

    }

}
