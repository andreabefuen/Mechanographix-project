using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {


    static List<int> utilizados;

    private static string[] wordList ={
        "padre", "moto",
        "ocho", "bonito", "diez",
        "colores", "jarra", "diezmar",
        "pala", "acera", "junta", "casa", "direccion",
        "palaciego", "ocupado", "llovizna",
        "seguro", "problemas", "reducir", "mejorar", "escapada" };

   public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        /*while(utilizados.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, wordList.Length);
        }
        utilizados.Add(randomIndex);*/
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}
