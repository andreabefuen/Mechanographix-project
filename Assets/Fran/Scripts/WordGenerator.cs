using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {


    static List<string> utilizados = new List<string>();

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
        
        while(MismaInicial(randomIndex))
        {           
                randomIndex = Random.Range(0, wordList.Length);          
        }
        utilizados.Add(wordList[randomIndex]);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }

    static bool MismaInicial(int index)
    {
        foreach (string palabra in utilizados)
        {
            if (wordList[index][0] == palabra[0])
            {
                return true;
            }
 
        }
        return false;
    }
}
