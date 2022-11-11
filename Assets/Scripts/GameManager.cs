using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static int currentLevelIndex;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

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
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassesRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlide.value = progress;

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level1");
            }
        }
        if (levelComplete)
        {
            levelCompletePanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
