using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadWords : MonoBehaviour {

    public TextAsset textFile;

    

    private string[] words  = new string[6];

	// Use this for initialization
	void Start () {
        string text = textFile.text;
        //Debug.Log(text);

        


        for (int i = 0; i < 6; i++)
        {
            string w = text.Split('\n')[i];

            words[i] = w;
        }

        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log("Palabra " + i + " " + words[i]);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}


    void readTextFile()
    {

        

    }
}
