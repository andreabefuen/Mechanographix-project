using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionNode:MonoBehaviour
{
    Point punto1, punto2, punto3;
    int puntos = 0;
    Transform intersec;

    PlayerMovement PlayerMov;

    public enum movimiento
    {
        SALTO,
        SUBIR,
        CAER,
        ANDAR
    };
    

    void Move(movimiento mov)
    {
        switch (mov)
        {
            case movimiento.SALTO:
                break;


            case movimiento.ANDAR:
                PlayerMov.MovePlayer(punto1.getPosition());
                break;


            case movimiento.CAER:
                break;


            case movimiento.SUBIR:
                break;


            default:
                break;
                //
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        

        intersec = this.transform;
        puntos = intersec.childCount;

        punto1 = new Point(intersec.Find("point1"));
        if (puntos > 1)
            punto2 = new Point(intersec.Find("point2"));
        if(puntos>2)
            punto3 = new Point(intersec.Find("point3"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


