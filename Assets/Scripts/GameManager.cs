using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute = false;
    public static bool trackMode = false;
    public static bool isGameStarted = false;
    public static bool isRestartOrNextLevel = false;
    public static bool isSetUp = false;
    public static int currentLevelIndex;
    public static int score = 0;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject trackModePanel;
    public GameObject startMenuPanel;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI trackScoreText;
    public TextMeshProUGUI highScoreText;

    public Slider gameProgressSlide;

    public static int numberOfPassesRings;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfPassesRings = 0;
        Time.timeScale = 1;
        gameOver = false;
        score = 0;
        levelComplete = false;
        isGameStarted = false;
        isSetUp = false;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);

        if (isRestartOrNextLevel)
        {
            StartGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassesRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlide.value = progress;

        scoreText.text = score.ToString();
        trackScoreText.text = "Score:\n" + score.ToString();

        //For mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {

            /*if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }*/

            /*StartGame();*/
        }

        if (gameOver)
        {
            Time.timeScale = 0;
            trackModePanel.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                isRestartOrNextLevel = true;
                SceneManager.LoadScene("Level1");
            }
        }

        if (levelComplete)
        {
            trackModePanel.gameObject.SetActive(false);
            levelCompletePanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                isRestartOrNextLevel = true;
                SceneManager.LoadScene("Level1");
            }
        }
    }

    public void StartGame()
    {
        if (trackMode)
        {
            currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
            gamePlayPanel.gameObject.SetActive(false);
            trackModePanel.gameObject.SetActive(true);
        }
        else
        {
            gamePlayPanel.gameObject.SetActive(true);
            trackModePanel.gameObject.SetActive(false);
        }
            
        startMenuPanel.SetActive(false);
        isGameStarted = true;
    }
}
