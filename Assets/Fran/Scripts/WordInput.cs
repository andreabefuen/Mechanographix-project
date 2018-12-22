using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{

    public WordManager wordManager;

    bool PrimerInput = true;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            if (PrimerInput)
            {
                PrimerInput = false;
                return;
            }
            wordManager.TypeLetter(letter);
        }
    }
}