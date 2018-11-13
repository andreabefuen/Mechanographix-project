using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDetection : MonoBehaviour
{
    public KeyCode _key;
    void OnTriggerStay(Collider other)
    {
        print("hola");
        if (other.GetComponent<CharacterMovement>().GetMoving() == false) {
            print("si pulsas la tecla: " + _key.ToString() + " entrarás al minijuego");
            if (Input.GetKeyDown(_key)) {
                SceneManager.LoadScene("EscenaPrueba2");
            }
        }
    }

}
