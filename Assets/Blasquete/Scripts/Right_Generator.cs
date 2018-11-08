using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Generator : MonoBehaviour {

    public GameObject[] myObjects;

    GameObject nextLetter;
    GameObject lastLetter;

    private bool right_isWorking;

    // Use this for initialization
    void Start()
    {
        right_isWorking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (right_isWorking)
        {
            InvokeRepeating("generateLetter", 2.0f, 2.0f);
            this.right_setWorking();
        }
    
        
    }

    void generateLetter()
    {
        nextLetter = myObjects[Random.Range(0, myObjects.Length)];
        if (lastLetter != nextLetter)
        {
            Instantiate(nextLetter, gameObject.transform.position, Quaternion.identity);
            lastLetter = nextLetter;
        }


    }

    public void right_setWorking()
    {
        this.right_isWorking = !right_isWorking;
    }

    public void stopGeneration()
    {
        CancelInvoke("generateLetter");
    }
}
