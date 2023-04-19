using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Text gameOverScoreText;

    public GameObject gameOverText;
    public bool isGameOver = false;
    public int score = 0;

    public GameObject pauseText;
    public AudioSource coinSource,deathSource,themeSource;
    

    private void Awake()
    {
        if (instance == null)
        {
            themeSource.Play();
            instance=this;
        }else if(instance==this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        coinSource.Play();
        this.score += score; 
        scoreText.text="Score: "+this.score;
    }
    public void GameOver()
    {
        themeSource.Stop();
        deathSource.Play();
        gameOverScoreText.text = "Your Score: " + this.score;
        gameOverText.SetActive(true);
        isGameOver= true;
    }
    public void pause()
    {
        pauseText.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
    }
    public void replay()
    {
        pauseText.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1;
    }
    public void stopSound()
    {
        
        themeSource.Pause();
        coinSource.volume = 0;
        deathSource.volume = 0;

    }
    public void replaySound()
    {

        themeSource.UnPause();
        coinSource.volume = 1f;
        deathSource.volume =1f;

    }
}
