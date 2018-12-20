using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //GameObject[] letters;
    private GameObject player;
    SpriteRenderer color;

    public KeyCode kcode;
    //string keyCode = "A";

    private float dist;
    private float velocity;
    private int currentScore;


    private GameController gameController;
    private int newScore = 10;

    void Start()
    {
        player = GameObject.Find("Player");
        color = GetComponent<SpriteRenderer>();



        GameObject gameControllerObject = GameObject.FindWithTag("GameSystem");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        velocity = gameController.getVelocityLvl();
        currentScore = gameController.getScore();
        
    }

    public void setVelocity()
    {
        if (gameController.getVelocityLvl() != velocity)
            Destroy(gameObject);

    }

    

    // Update is called once per frame
    void Update()
    {
        setVelocity();

        if (player.transform.position.x > this.transform.position.x)
            transform.Translate(Time.deltaTime * velocity, 0, 0);
        else if (player.transform.position.x < this.transform.position.x)
            transform.Translate(-(Time.deltaTime * velocity), 0, 0);

        dist = Vector3.Distance(player.transform.position, this.transform.position);

        if (dist <= 5)
        {
            color.color = new Color(255f, 0f, 0f, 1f);
            if (Input.GetKeyDown(kcode))
            {
                gameController.AddScore(newScore);
                Destroy(gameObject);
                
            }
        }

        if (dist <= 2)
            Destroy(gameObject);

        if (velocity != gameController.getVelocityLvl())
            Destroy(gameObject);

    }
}
