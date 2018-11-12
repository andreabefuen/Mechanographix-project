using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {


    public GameObject wordPrefab;
    public Transform wordCanvas;

    Vector3[] puntosDeSpawn= new Vector3[3];

	public WordDisplay SpawnWord(int num)
    {
        puntosDeSpawn[0] = new Vector3(70f, 70f);
        puntosDeSpawn[1] = new Vector3(100f, 0f);
        puntosDeSpawn[2] = new Vector3(70f, -70f);

        GameObject wordObj = Instantiate(wordPrefab,puntosDeSpawn[num],Quaternion.identity, wordCanvas);
        WordDisplay display = wordObj.GetComponent<WordDisplay>();

        return display;
    }

}
