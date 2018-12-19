using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerDetection : MonoBehaviour
{
    public KeyCode _key;
    public GameObject dialogBox;
    public string escena;

    private void OnTriggerEnter(Collider other)
    {
        dialogBox.SetActive(true);
        dialogBox.GetComponentInChildren<Text>().text = "si pulsas la tecla: " + _key.ToString() + " entrarás al minijuego";
    }

    void OnTriggerStay(Collider other)
    {
        print("hola");
        if (other.GetComponent<CharacterMovement>().GetMoving() == false) {
            if (Input.GetKeyDown(_key)) {
                dialogBox.SetActive(false);
                SceneManager.LoadScene(escena);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogBox.SetActive(false);
    }

}
