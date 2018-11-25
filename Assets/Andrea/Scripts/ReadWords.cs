﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadWords : MonoBehaviour {

    public TextAsset textFile;

    public int cantidadPalabras;

    [SerializeField]
    private string[] words;


    private void Awake()
    {
        string text = textFile.text;
        //Debug.Log(text);

        words = new string[cantidadPalabras];



        for (int i = 0; i < cantidadPalabras; i++)
        {
            string w = text.Split(' ')[i];
            w.Remove(w.Length-1);
            words[i] = w;
        }

       // for (int i = 0; i < words.Length; i++)
       // {
       //     Debug.Log("Palabra " + i + " " + words[i]);
       // }
    }

    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update () {
		
	}

    public string[] GetWordInFile()
    {
        return words;
    }

    public string ReturnRandomWord()
    {
        int index = Random.Range(0, words.Length);

        //Debug.Log("PALABRA RANDOM: " + words[index]);

        return words[index];
    }


    void readTextFile()
    {

        

    }
}
