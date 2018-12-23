using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerPause : MonoBehaviour
{
    public KeyCode _key;
    public GameObject dialogBox;
    PauseMenu pauseMenu;

    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogBox.SetActive(true);
        dialogBox.GetComponentInChildren<Text>().text = "Pulsa RETROCESO <-- si quieres consultar el menú de pausa";
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterMovement>().GetMoving() == false)
        {
            if (Input.GetKeyDown(_key))
            {
                dialogBox.SetActive(false);
                pauseMenu.Pause();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogBox.SetActive(false);
    }
}
