using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    private int score;

    UIManager ui;

    public void Start()
    {
        ui = FindObjectOfType<UIManager>();
        ui.SetScoreText("Score: " + score);
    }

    public void Update()
    {
        if(isGameOver)
        {
            ui.ShowGameoverPanel(true);           
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void SetScore(int value)
    {
        score = value;
    }

    public int  GetScore()
    {
        return score;
    }

    public void ScoreUp()
    {
        score++;
        ui.SetScoreText("Score: " + score);
    }

    public bool GameOver()
    {
        return isGameOver;
    }

    public void SetGameOverState(bool state)
    {
        isGameOver = state;
    }
}
