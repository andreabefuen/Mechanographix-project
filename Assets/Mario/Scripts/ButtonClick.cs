using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public KeyCode _key;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(_key))
        {
            print(_key);
            //Click the button
            _button.onClick.Invoke();
            FadeToColor(_button.colors.pressedColor);
        }
        else if (Input.GetKeyUp(_key)) {
            FadeToColor(_button.colors.normalColor);
        }
	}

    void FadeToColor(Color color) {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }

}
