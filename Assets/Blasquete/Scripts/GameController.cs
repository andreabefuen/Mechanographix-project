using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject[] letters;

    public Text scoreText;
    public Text levelText;
    public Text avisoText;
    private int score;
    private int totalScore;
    private int level;
    private float velocity_lvl;

    public LeftGenerator leftGenerator;
    public RightGenerator rightGenerator;
    // Use this for initialization
    void Start()
    {
        score = 0;
        totalScore = 0;
        level = 1;
        velocity_lvl = 0.2f;
        UpdateScore();
        UpdateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
        checkVelocityLvl();

        
    }

    void checkVelocityLvl() {
        if (score < 100)
            velocity_lvl = 0.2f;
        else if (score < 150)
            velocity_lvl = 0.4f;
        else if (score < 200)
            velocity_lvl = 0.6f;
    }

    void checkLevel() {
        if (totalScore == 200 && level == 1)
        {
            level = 2;
            score = 0;
            UpdateLevel();


            leftGenerator.stopGeneration();

            StartCoroutine(cleanLetters());


        }

        else if (totalScore == 400 && level == 2)
        {
            level = 3;
            score = 0;
            UpdateLevel();

            leftGenerator.left_setWorking();

        }

        else if (totalScore == 600 && level == 3)
        {
            level = 4;
            score = 0;
            UpdateLevel();
        }
    }

    IEnumerator cleanLetters()
    {
        letters = GameObject.FindGameObjectsWithTag("letter");

        for (var i = 0; i < letters.Length; i++)
        {
            Destroy(letters[i]);
        }

        yield return new WaitForSeconds(5);

        rightGenerator.right_setWorking();
    }

   


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        totalScore += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Puntos: " + totalScore;
    }

    void UpdateLevel()
    {
        levelText.text = "Nivel: " + level;
    }

    public int getScore()
    {
        return score;
    }

    public void setLevel(int n)
    {
        level = n;
    }

    public int getLevel()
    {
        return level;
    }

    public float getVelocityLvl() {
        return velocity_lvl;
    }
}