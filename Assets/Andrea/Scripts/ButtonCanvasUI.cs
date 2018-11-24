using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanvasUI : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }
    public void OnStartButton()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
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
