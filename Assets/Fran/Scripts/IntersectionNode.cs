using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionNode
{
    Transform punto1, punto2, punto3;

    public enum movimiento
    {
        SALTO,
        SUBIR,
        CAER,
        ANDAR
    };

    IntersectionNode (Transform punto1, Transform punto2, Transform punto3)
    {
        this.punto1 = punto1;
        this.punto2 = punto2;
        this.punto3 = punto3;


    }


    void Move(movimiento mov)
    {
        switch (mov)
        {
            case movimiento.SALTO:
                break;


            default:
                break;
                //
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
