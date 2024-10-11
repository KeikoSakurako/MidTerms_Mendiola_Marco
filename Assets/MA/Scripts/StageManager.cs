using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //to pause the games
    public GameObject PausePanel;
    public static bool ispause;

    //Kill
    public int killfeed;
    public Text scoretext;
    public static StageManager instanse;

    //Timer
    public Text timertext;
   
    public float elapsedTime;

    //Game Over scene
    public GameObject gameover;
    bool gamehasend = false;

    //EndGameScreen
    public GameObject endscreen;
    

    //GameOver
    public void GameOverScreen()
    {
        if (gamehasend == false)

        {
            gamehasend = true;
            Time.timeScale = 0;
            Debug.Log("GameOver");
            gameover.SetActive(true);
        }


    }


    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }


    //================================

    public void PauseMenu()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        ispause = true;
    }


    public void ContinueGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        ispause = false;
    }

    public void EndGameScreen()
    {
        endscreen.SetActive(true);

        Time.timeScale = 0;
        ispause = true;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        ispause = false;

    }


    //=====================================================
    private void Awake()
    {
        instanse = this;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timertext.text = elapsedTime.ToString();
        

        //Kill display
        scoretext.text = "Kill: " + killfeed.ToString();
    }

    public void KillCount(int k)
    {
        killfeed += k;
        scoretext.text = killfeed.ToString();
    }


}
