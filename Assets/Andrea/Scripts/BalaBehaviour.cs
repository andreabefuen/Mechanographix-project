﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{

    public float speed;
    public Transform sphere;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponentInChildren<Transform>().Find("pSphere4");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        if (screenPoint.x > 1)
        {
            Destroy(this.gameObject);
        }

        sphere.localEulerAngles = new Vector3 (0,0, sphere.localEulerAngles.z + speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameBehaviour.Score += 100;
            Destroy(other.gameObject, 0.5f);
        }
    }
}

