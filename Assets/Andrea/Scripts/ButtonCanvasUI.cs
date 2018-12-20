using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanvasUI : MonoBehaviour
{
    public GameObject texto;
    public GameObject paneltimer;
    public GameObject panelscore;

    private void Awake()
    {
        Time.timeScale = 0;
        texto.SetActive(false);
        panelscore.SetActive(false);
        paneltimer.SetActive(false);
    }
    public void OnStartButton()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        texto.SetActive(true);
        panelscore.SetActive(true);
        paneltimer.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
