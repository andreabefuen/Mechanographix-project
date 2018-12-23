using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerDetection : MonoBehaviour
{
    public KeyCode _key;
    public GameObject dialogBox;
    public int escena;
    LevelChanger levelChanger;
    
    

    private void Awake()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogBox.SetActive(true);
        switch (_key) {
            case KeyCode.Alpha3:
                dialogBox.GetComponentInChildren<Text>().text = "si pulsas la tecla: 3 entrarás al minijuego";
                break;
            case KeyCode.Alpha7:
                dialogBox.GetComponentInChildren<Text>().text = "si pulsas la tecla: 7 entrarás al minijuego";
                break;
            case KeyCode.LeftBracket:
                dialogBox.GetComponentInChildren<Text>().text = "si pulsas la tecla: ? entrarás al minijuego";
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterMovement>().GetMoving() == false) {
            if (Input.GetKeyDown(_key)) {
                dialogBox.SetActive(false);
                levelChanger.FadeToLevel(escena);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogBox.SetActive(false);
    }

}
