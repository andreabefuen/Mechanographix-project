using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {

    public InputField mainInput;

    [SerializeField]
    private Text[] spawnTexts;

    [SerializeField]
    private GameObject[] shootersObjects;





    private string inputStringUser;

    ReadWords readWords;

    private string[] words;


    private void Awake()
    {
        readWords = GetComponent<ReadWords>();

        words = readWords.GetWordInFile();

     
       //
       // spawn1text.text = readWords.ReturnRandomWord();
       // spawn2text.text = readWords.ReturnRandomWord();
       // spawn3text.text = readWords.ReturnRandomWord();
       // spawn4text.text = readWords.ReturnRandomWord();
    }

    private void Start()
    {

        for (int i = 0; i < spawnTexts.Length; i++)
        {
            spawnTexts[i].text = readWords.ReturnRandomWord();
            Debug.Log(spawnTexts[i].text);
        }



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
            Debug.Log(inputStringUser.Length);

            for (int i = 0; i < spawnTexts.Length; i++)
            {

                Debug.Log("spawn text longitud " + spawnTexts[i].text.Length);

                //Debug.Log("pene");
                if (spawnTexts[i].text == inputStringUser) 
                {
                    Debug.Log("TA BIEN ESCRITO");
                    shootersObjects[i].GetComponent<ShooterBehaviour>().Shot();

                    spawnTexts[i].text = readWords.ReturnRandomWord();

                }


            }

        }
    }
}
