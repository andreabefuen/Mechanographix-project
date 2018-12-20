using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour  
{
    private const string FADE_OUT = "FadeOut";
    public Animator anim;
    int levelToLoad;

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        anim.SetTrigger(FADE_OUT);
    }

    void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
