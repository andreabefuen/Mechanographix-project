using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{


    Transform position;
    public Transform siguiente;

    public Movimiento movType;

    

    public Point (Transform position)
    {
        this.position = position;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPosition()
    {
        return position.position;
    }
}
