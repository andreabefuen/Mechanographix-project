using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{

    public float speed;
    public Transform sphere;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponentInChildren<Transform>().Find("pSphere4");

        audio = this.gameObject.GetComponent<AudioSource>();
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

        sphere.localEulerAngles = new Vector3 (0,0, sphere.localEulerAngles.z + speed * Time.deltaTime * 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameBehaviour.Score += 100;
            audio.Play();
            other.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            sphere.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(other.gameObject, 1.8f);
            Destroy(this.gameObject, 0.5f);
        }
    }
}

