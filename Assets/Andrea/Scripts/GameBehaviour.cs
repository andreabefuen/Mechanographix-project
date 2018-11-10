using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {

    public InputField mainInput;

    [SerializeField]
    private Text[] spawnTexts;


    private Text spawn1text;
    private Text spawn2text;
    private Text spawn3text;
    private Text spawn4text;




    private string inputStringUser;

    private void Start()
    {
        spawn1text = spawnTexts[0];
        spawn2text = spawnTexts[1];
        spawn3text = spawnTexts[2];
        spawn4text = spawnTexts[3];

        //mainInput.onValueChanged.AddListener(delegate { OnTextChange(); });
    }

    void OnTextChange()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputStringUser = mainInput.text;
            mainInput.text = "";

            Debug.Log("Se ha escrito: " + inputStringUser);

            for (int i = 0; i < spawnTexts.Length; i++)
            {
                if(spawnTexts[i].text == inputStringUser)
                {
                    Debug.Log("TA BIEN ESCRITO");
                }

            }

        }
    }
}
