using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WordDisplay : MonoBehaviour {

    public Text text;
    private string seguridad;

    public void SetWord(string word)
    {
        text.text = word;
        seguridad = word;
    }


    public void PaintLetter()
    {

        text.text = text.text.Remove(0, 1);
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public void ResetWord()
    {
        text.text = seguridad;
    }

}
