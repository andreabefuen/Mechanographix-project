using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> words;
 

    public WordSpawner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    public GameObject Interseccion;
    public int cantidad;

    GameObject player;
    PlayerMovement playerMove;

    GameObject WordToMove;
    Vector3 WordPosition;
    bool wordOnScreen;

    

    private void Awake()
    {
        
    }

    void Start ()
    {

        Interseccion = GameObject.FindGameObjectWithTag("StartingGroup");
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        cantidad = Interseccion.GetComponent<IntersectionNode>().puntos;

        for (int i = 1; i < cantidad+1; i++)//sumo uno para hacer la cadena en AddWord sin tener que sumar nada
        {
            AddWord(i);
        }
        playerMove.GetStart(Interseccion.transform.Find("Start").transform.position);
        playerMove.MoveToStart(Interseccion.transform.Find("Start").transform.position);
    }
	
                                        //   el codigo de caracter de backspace es \b

    public void AddWord(int num)
    {
        string cadena = "point" + num.ToString();
        WordPosition = Interseccion.transform.Find(cadena).transform.position;
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord(Interseccion.transform.Find(cadena)));
        WordToMove = wordSpawner.wordObj;
        words.Add(word);
        wordOnScreen = true;

    }
    public void Update()
    {
        if (wordOnScreen)
            WordToMove.transform.position = WordPosition;
    }


    public void TypeLetter(char letter) 
    {
        

        //Debug.Log("letra:" + letter + ".");
        if ((letter.Equals('\b') || letter.Equals(KeyCode.Backspace)) && hasActiveWord)
        {

            hasActiveWord = false;
            activeWord.ResetIndex();

        }
        
        else if (hasActiveWord)         
        {
            if(activeWord.GetNextLetter()==letter)
            {
                activeWord.TypeLetter();
            }
            else///////ERRROR A MITAD DE PALABRA
            {
                //Debug.Log("laca:  caste" );
               
                    Error();
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

                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
                else      ///////ERRROR AL EMPEZAR PALABRA
                {
                    //Debug.Log("laca:  caste con la primera");
                   
                        Error();
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())             //palabra completada
        {
            hasActiveWord = false;

            int punto = words.IndexOf(activeWord);      //punto+1 es el punto al que ir

            words.Remove(activeWord);

            foreach (Word word in words)   //borramos TODAS las palabras para ir a la siguiente intersección
            {
                word.RemoveDisplay();
                
            }
            words.Clear();
            string cadena2 = "point" + (punto+1);

            Point destino = Interseccion.transform.Find(cadena2).GetComponent<Point>();


            playerMove.MoveToTarget(destino);

            Interseccion = destino.siguiente;

            
            playerMove.GetStart(Interseccion.transform.Find("Start").transform.position);


            if (Interseccion.tag == "Goal")
            {
                playerMove.FinishGame();
                wordOnScreen = false;
            }
            else
            {
                for (int i = 1; i < cantidad + 1; i++)//sumo uno para hacer la cadena en AddWord sin tener que sumar nada
                {
                    AddWord(i);
                }
            }
        }
    }

    public void Error()
    {
        playerMove.Error();
    }
}
