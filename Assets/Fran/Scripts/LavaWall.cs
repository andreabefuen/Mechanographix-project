using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWall : MonoBehaviour
{
    public bool moving;
    public float scrollingSpeed = 4f;
    public Transform wall;
    public bool Death = false;

    // Start is called before the first frame update
    void Start()
    {
        wall = GetComponent<Transform>();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        wall.position += Vector3.right * scrollingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Death = true;
            Stop();
        }
    }

    public void  Stop()
    {
        moving = false;
    }
}
