using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 target;
    Transform player;
    bool moving = false;
    bool climbing = false;
    bool falling = false;
    bool jumping = false;
    float maxSpeed = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            Move();
        }
        if(Vector3.Distance(transform.position, target)<=0.05f)
        {
            moving = false;
            climbing = false;
            falling = false;
            jumping = false;
        }
    }


    public void MoveTarget(Vector3 movePoint, Movimiento mov)
    {
        target = movePoint;

        switch (mov)
        {
            case Movimiento.SALTAR:
                jumping = true;
                break;


            case Movimiento.ANDAR:
                moving = true;
                break;


            case Movimiento.CAER:
                falling = true;
                break;


            case Movimiento.SUBIR:
                climbing = true;
                break;

        }

    }

    void Move()
    {
        //transform.position += maxSpeed * Time.deltaTime;
    }
}
