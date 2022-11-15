using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnclickEvents : MonoBehaviour
{

    public TextMeshProUGUI soundText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (GameManager.mute)
        {
            soundText.text = "/";
        }
        else
        {
            soundText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() { 
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            soundText.text = "";
            GameManager.mute = false;
        } else
        {
            soundText.text = "/";
            GameManager.mute = true;
        }
    }

    public void MainMenu()
    {
        GameManager.isRestartOrNextLevel = false;
        GameManager.isGameStarted = false;
        SceneManager.LoadScene("Level1");
    }
    
    public void TrackMode()
    {
        GameManager.score = 0;
        GameManager.trackMode = true;
        gameManager.StartGame();
    } 

    public void RestartGame()
    {
        GameManager.score = 0;
        GameManager.isRestartOrNextLevel = true;
        SceneManager.LoadScene("Level1");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        GameManager.trackMode = false;
        GameManager.currentLevelIndex = 1;
        GameManager.score = 0;
        PlayerPrefs.SetInt("currentLevelIndex", 1);
        //PlayerPrefs.GetInt("currentLevelIndex", 1);
        gameManager.StartGame();
    } 
    
    public void ContinueGame()
    {
        GameManager.trackMode = false;
        gameManager.StartGame();
    }
}
