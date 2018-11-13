using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyClick : MonoBehaviour {

    private GameObject character;
    private Color DefaultColor;
    public Color PressedColor;
    public KeyCode _key;   
    public float FadeColorTime = 0.1f;

    // Use this for initialization
    void Start () {
        character = GameObject.FindGameObjectWithTag("Player");
        DefaultColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(_key))
        {
            //Click the button
            GetComponent<Renderer>().material.color = PressedColor;
            character.GetComponent<CharacterMovement>().MoveCharacterTo(transform.position);//hacer que el player se mueva a la posicion de la "tecla"
        }
        else if (Input.GetKeyUp(_key))
        {
            GetComponent<Renderer>().material.color = DefaultColor;
        }

    }

    void FadeToColor(Color startColor, Color endColor)
    {
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, FadeColorTime);
    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
            Debug.Log("Detected key code: " + e.keyCode);

    }
}
