using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    private GameObject player;
    private float dist;
    private float moveSpeed;
    public KeyCode kcode;


    private int currentScore;


    private GameController gameController;
    private int newScore = 10;

    private Animator anim;
    bool aux = false;

    void Start() {
        player = GameObject.Find("Player");

        GameObject gameControllerObject = GameObject.FindWithTag("GameSystem");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        moveSpeed = gameController.getVelocityLvl();
        currentScore = gameController.getScore();

        anim = player.gameObject.GetComponent<Animator>();
    }

    public void setVelocity()
    {
        if (gameController.getVelocityLvl() != moveSpeed)
            Destroy(gameObject);

    }

    void Update()
    {

        setVelocity();

        transform.LookAt(player.transform.position);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 1)
        {
            Debug.Log("ESTÁ CERCA");
            if (Input.GetKeyDown(kcode))
            {
                gameController.AddScore(newScore);
                Destroy(gameObject);

            }
        }

        if (dist < .2 && aux == false)
        {
            anim.SetTrigger("isDamageTrigger");
            Destroy(gameObject);
            AuxSet();
            aux = true;




        }

        if (moveSpeed != gameController.getVelocityLvl())
            Destroy(gameObject);
    }
    public void AuxSet()
    {

        Invoke("AuxAux", 1f);

    }
    void AuxAux()
    {
        anim.SetBool("isDamage", false);
        Debug.Log("PENE");
    }

    public void setKeyCode(KeyCode newKey) {
        kcode = newKey;
    }
}
