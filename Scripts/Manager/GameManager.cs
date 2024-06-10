using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI endScoreText;
    public GameObject gameOverUI;

    private float startTime;
    private float bestScore = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        UpdateScoreText(0);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
            return;

        float t = Time.time - startTime;
        UpdateScoreText(t);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);

        float endScore = Time.time - startTime;
        endScoreText.text = endScore.ToString("F2");

        if (endScore > bestScore)
        {
            bestScore = endScore;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            bestScoreText.text = bestScore.ToString("F2");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void UpdateScoreText(float time)
    {
        scoreText.text = time.ToString("F2");
    }
}