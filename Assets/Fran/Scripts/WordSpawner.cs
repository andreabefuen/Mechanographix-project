using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {


    public GameObject wordPrefab;
    public Transform wordCanvas;
    public GameObject wordObj;


	public WordDisplay SpawnWord( Transform punto)
    {
        

        wordObj = Instantiate(wordPrefab,punto.position,Quaternion.identity, wordCanvas);
        WordDisplay display = wordObj.GetComponent<WordDisplay>();

        return display;
    }

}
