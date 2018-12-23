using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerActiveKeyboard : MonoBehaviour
{
    public KeyCode _key;
    public GameObject dialogBox;
    public GameObject keyboard3D;
    public GameObject keyboardLayout;


    private void OnTriggerEnter(Collider other)
    {
        dialogBox.SetActive(true);
        dialogBox.GetComponentInChildren<Text>().text = "Pulsa Z si quieres activar el teclado 3D";
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterMovement>().GetMoving() == false)
        {
            if (Input.GetKeyDown(_key))
            {
                dialogBox.SetActive(false);
                if (keyboard3D.activeSelf)
                {
                    keyboard3D.SetActive(false);
                    keyboardLayout.SetActive(true);
                }
                else {
                    keyboard3D.SetActive(true);
                    keyboardLayout.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogBox.SetActive(false);
    }

}
