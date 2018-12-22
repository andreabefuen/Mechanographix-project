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
    public bool getDamage = false;

    LavaWall lavaWall;
    LevelChanger Level;
    public GameObject Victory;
    public GameObject ErrorFlash;
    public GameObject Defeat;
    public GameObject Imagen;
    AudioSource Sound;
    Animator anim;
    public bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        lavaWall = GameObject.FindGameObjectWithTag("LavaWall").GetComponent<LavaWall>();
        Sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Level =GameObject.FindGameObjectWithTag("GameSystem").GetComponent<LevelChanger>();
        //Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Imagen.activeInHierarchy)
        {
            Time.timeScale = 1;

            if (lavaWall.Death)
            {
                Defeat.SetActive(true);
                lavaWall.Stop();
                return;
            }

            if (walking || starting || falling || jumping)
            {

                if (!Sound.isPlaying)
                    Sound.Play();
                velocity = target - transform.position;
                velocity.Normalize();
                waiting = false;
                Move();
            }
            if (Vector3.Distance(transform.position, target) <= 0.35f && !starting)
            {

                walking = false;
                climbing = false;
                falling = false;
                jumping = false;

                transform.position = target;
                if (!waiting)
                {
                    MoveToStart(nextStart);
                }
                if (Goal)
                {
                    Victory.SetActive(true);
                    lavaWall.Stop();
                    StartCoroutine(Wait(3));

                }

            }
            else if (Vector3.Distance(transform.position, target) <= 0.35f)
            {
                Sound.Stop();

                starting = false;
                transform.position = target;
                waiting = true;
            }


            if (walking || starting || jumping)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
            }
            else if (falling)
            {
                anim.SetBool("jumping", true);
                anim.SetBool("walking", false);
                anim.SetBool("idle", false);
            }
            else if (!falling && !climbing)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("walking", false);
                anim.SetBool("idle", true);
            }
            /*
                    SpriteRenderer lava = lavaWall.GetComponent<SpriteRenderer>();
                    lava.sharedMaterial.SetTextureOffset("lava", new Vector2(2,2));
            */


            SpriteRenderer bloodImage = ErrorFlash.GetComponent<SpriteRenderer>();
            if (getDamage)
            {
                Color Opaque = new Color(1, 1, 1, 1);
                ErrorFlash.SetActive(true);
                bloodImage.color = Color.Lerp(bloodImage.color, Opaque, 20 * Time.deltaTime);
                if (bloodImage.color.a >= 0.8) //Almost Opaque, close enough
                {
                    getDamage = false;
                }
            }
            if (!getDamage)
            {

                Color Transparent = new Color(1, 1, 1, 0);
                bloodImage.color = Color.Lerp(bloodImage.color, Transparent, 20 * Time.deltaTime);
                ErrorFlash.SetActive(false);
            }

        }
        else
        {
            Time.timeScale = 0;
            if(Input.GetKeyDown("return"))
            {
                Imagen.SetActive(false);
            }

              
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
    
    IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
        Level.FadeToLevel(0);
        
    }

    public void Error()
    {

        getDamage = true;
    

        if(lavaWall.scrollingSpeed<15f)
            lavaWall.scrollingSpeed *= 1.2f;

  
    }

    public void FinishGame()
    {
        Goal = true;
    }
}
