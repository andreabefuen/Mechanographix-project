using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed;
    private bool moving;
    private Vector3 goal;

    // Use this for initialization
    void Start ()
    {
        goal = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x != goal.x) || (transform.position.z != goal.z))
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, Time.deltaTime * speed);
            Vector3 direction = goal - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f);
            moving = true;
        }
        else if (moving)
        {
            moving = false;
        }
    }

    public void MoveCharacterTo(Vector3 goal) {
        if ((this.goal.x != goal.x) || (this.goal.z != goal.z)) {
            this.goal.x = goal.x;
            this.goal.z = goal.z;
        }
    }

    public bool GetMoving()
    {
        return moving;
    } 
}
