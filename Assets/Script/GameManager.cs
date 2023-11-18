using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public bool isGameOver = false;
    public TextMeshProUGUI scoreText;

    public void AddScore(int scorePoint)
    {
        score += scorePoint;
        scoreText.text = "Score: " + scorePoint.ToString();
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        Debug.Log("GAME OVER!");
    }



}