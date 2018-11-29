using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> words;
    public int cantidad;

    public WordSpawner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    public GameObject Interseccion;

    private void Awake()
    {
        Interseccion = GameObject.FindGameObjectWithTag("StartingGroup");
    }

    void Start () {

        for(int i = 1; i < cantidad+1; i++)
        {
            AddWord(i);
        }
		
	}
	
                                        //   el codigo de caracter de backspace es \b

    public void AddWord(int num)
    {
        string cadena = "point" + num.ToString();
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord(Interseccion.transform.Find("cadena")));

        words.Add(word);

    }


    public void TypeLetter(char letter)
    {
        Debug.Log("letra:" + letter + ".");
        if ((letter.Equals('\b') || letter.Equals(KeyCode.Backspace)) && hasActiveWord)
        {
            Debug.Log("palabra reseteada");
            hasActiveWord = false;
            activeWord.ResetIndex();

        }
        if (hasActiveWord)
        {
            if(activeWord.GetNextLetter()==letter)
            {
                activeWord.TypeLetter();
            }
            //check if letter was next
            //remove from word
        }
        else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter()==letter)
                {
                    Debug.Log("palabra activada");
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);


        }
    }
}
