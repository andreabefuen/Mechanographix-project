using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    Transform player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void MovePlayer(Vector3 movePoint)
    {
        player.Translate(Vector3.Lerp(player.position, movePoint, Time.deltaTime));

    }
}
