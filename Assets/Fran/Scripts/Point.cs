using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{


    Transform position;
    public GameObject siguiente;

    public Movimiento movType;

    

    public Point (Transform position)
    {
        this.position = position;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform;
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
