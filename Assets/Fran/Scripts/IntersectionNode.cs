using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public enum Movimiento
{
    SALTAR,
    SUBIR,
    CAER,
    ANDAR
};



public class IntersectionNode:MonoBehaviour
{
    public Point punto1, punto2, punto3;
    public int puntos = 1;
    Transform intersec;
    
    public PlayerMovement PlayerMov;



    private void Awake()
    {
        intersec = this.transform;
        puntos = intersec.childCount - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();


        intersec = this.transform;
        puntos = intersec.childCount - 1;


        punto1 = intersec.Find("point1").GetComponent<Point>();
        if (puntos > 1)
            punto2 = intersec.Find("point2").GetComponent<Point>();
        if (puntos>2)
            punto3 = intersec.Find("point3").GetComponent<Point>(); 


    }

    // Update is called once per frame
    void Update()
    {
      
    }
}


