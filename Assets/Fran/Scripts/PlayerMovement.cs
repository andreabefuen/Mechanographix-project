using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 target = new Vector3();
    bool walking = false;
    public bool climbing = false;
    public bool falling = false;
    public bool jumping = false;
    public bool starting = false;
    float maxSpeed = 40f;
    float jumpHeight = 6f;
    Vector3 midjump = new Vector3(0, 0, 0);
    Vector3 topFall = new Vector3(0, 0, 0);
    Vector3 nextStart = new Vector3(0, 0, 0);
    public float jumpVelocity = 4.5f;
    Vector3 velocity = new Vector3(0, 0, 0);
    public bool Goal = false;

    LavaWall lavaWall;

    public GameObject Victory;
    public GameObject ErrorFlash;
    public GameObject Defeat;
    AudioSource Sound;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lavaWall = GameObject.FindGameObjectWithTag("LavaWall").GetComponent<LavaWall>();
        Sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(lavaWall.Death )
        {
            Defeat.SetActive(true);
            lavaWall.Stop();
            return;
        }

        if(walking||starting||falling||jumping)
        {
            
            if(!Sound.isPlaying)
                Sound.Play();
            velocity = target - transform.position;
            velocity.Normalize();
            Move();
        }    
        if(Vector3.Distance(transform.position, target)<=0.35f && !starting)
        {
            
            walking = false;
            climbing = false;
            falling = false;
            jumping = false;
            
            



            transform.position = target;
            MoveToStart(nextStart);
            if (Goal)
            {
                Victory.SetActive(true);
                lavaWall.Stop();
                return;
            }

        }
        else if (Vector3.Distance(transform.position, target) <= 0.35f)
        {
            Sound.Stop();

            starting = false;
            transform.position = target;
        }


        if(jumping)
        {
            anim.SetBool("jumping", true);
            anim.SetBool("walking", false);
            anim.SetBool("idle", false);
        }
        else if (walking)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);
        }
        else if (!falling && !climbing)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("walking", false);
            anim.SetBool("idle", true);
        }


    }

    public void MoveToTarget(Point punto)
    {
        target = punto.getPosition();

        switch (punto.movType)
        {
            case Movimiento.SALTAR:
                jumping = true;
                
                midjump.y = target.y + jumpHeight;
                midjump.x = (target.x - transform.position.x) / 2;
                break;


            case Movimiento.ANDAR:

                walking = true;
                break;


            case Movimiento.CAER:

                falling = true;
                topFall.y = transform.position.y + 4;
                topFall.x = (target.x - transform.position.x)/2;
                break;


            case Movimiento.SUBIR:
                climbing = true;
                break;

        }

    }

    void Move()
    {
        if (walking || jumping || starting )
        {
            //velocity.Normalize();
            transform.position += velocity * maxSpeed * Time.deltaTime;
        }
        if (jumping)
        {
            float difference = midjump.y - transform.position.y;
            if (transform.position.x < midjump.x)
            {
                velocity.y = -jumpVelocity * (0.5f + difference / 2f);
                velocity.x = 0;
                transform.position += velocity * Time.deltaTime;
               
            }
            else
            {
                velocity.y = jumpVelocity * (0.5f + difference / 2f);
                velocity.x = 0;
                transform.position += velocity * Time.deltaTime;
            }
            velocity.y = 0;
        }
        if (falling)
        {
            transform.position += velocity * maxSpeed * Time.deltaTime;

            float difference = topFall.y - transform.position.y;
            if (transform.position.x < topFall.x)
            {
                velocity.y = -jumpVelocity * (0.5f + difference / 2f);
                velocity.x = 0;
                transform.position += velocity * Time.deltaTime;

            }
            else
            {
                velocity.y = jumpVelocity * (0.5f + difference / 2f);
                velocity.x = 0;
                transform.position += velocity * Time.deltaTime;
            }
        }
        velocity = Vector3.zero;
    }


    public void MoveToStart(Vector3 start)
    {
        //molaria pausa aqui
       
        
        //StartCoroutine(Example(5, start));        
        target = start;
        starting = true;
    }

    public void GetStart(Vector3 s)
    {
        nextStart = s;
    }
    
    IEnumerator Example(float s, Vector3 v)
    {
        yield return new WaitForSeconds(s);
        
    }

    public void Error()
    {                   //SE HA CAIDO UNITY ANSWERS EQUISDE MIRAR COMO SE CAMBIABA EL ALPHA COMO LERP
        if(lavaWall.scrollingSpeed<15f)
            lavaWall.scrollingSpeed *= 1.2f;
        ErrorFlash.SetActive(true);
        //ErrorFlash.GetComponent<SpriteRenderer>().
    }

    public void FinishGame()
    {
        Goal = true;
    }
}
