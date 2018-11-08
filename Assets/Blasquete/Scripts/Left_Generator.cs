using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Generator : MonoBehaviour
{

    public GameObject[] myObjects;

    GameObject nextLetter;
    GameObject lastLetter;

    private bool left_isWorking;

    //private int n_letters;


    // Use this for initialization
    void Start()
    {
        left_isWorking = true;
        //n_letters = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (left_isWorking)
        {
            InvokeRepeating("generateLetter", 2.0f, 2.0f);
            this.left_setWorking();
        }

    }

    void generateLetter()
    {
        nextLetter = myObjects[Random.Range(0, myObjects.Length)];
        if (lastLetter != nextLetter )
        {
            
            Instantiate(nextLetter, gameObject.transform.position, Quaternion.identity);
            lastLetter = nextLetter;
            
        }


    }

    public void left_setWorking()
    {
        this.left_isWorking = !left_isWorking;

    }

    public void stopGeneration()
    {
        CancelInvoke("generateLetter");
    }

    /*public void setNumLetters()
    {
        this.n_letters = 0;
    }*/
}
