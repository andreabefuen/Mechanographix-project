using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGenerator : MonoBehaviour
{
    public Sprite[] myObjects;
    public KeyCode[] keyCodes;

    public GameObject letter;

    Sprite nextLetter;
    Sprite lastLetter;

    private SpriteRenderer spriteR;

    private int rand;

    private KeyMovement keyMovement;

    private bool right_isWorking;

    //private int n_letters;


    // Use this for initialization
    void Start()
    {
        right_isWorking = false;
        spriteR = letter.GetComponentInChildren<SpriteRenderer>();
        

        keyMovement = letter.GetComponent<KeyMovement>();
        //n_letters = 0;
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
        rand = Random.Range(0, myObjects.Length);
        nextLetter = myObjects[rand];

        if (lastLetter != nextLetter)
        {
            spriteR.sprite = nextLetter;
            keyMovement.setKeyCode(keyCodes[rand]);
            Instantiate(letter, gameObject.transform.position, Quaternion.identity);
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

    /*public void setNumLetters()
    {
        this.n_letters = 0;
    }*/
}
