using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM1 : MonoBehaviour
{
    public static GM1 Instance;

    bool isGameOver = false;

    int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject gameoverPanel;

    [SerializeField] Button restartBtn;
    [SerializeField] Button MenuBtn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ButtonsWorkings();
    }
    public void GameOver()
    {
        isGameOver = true;
        GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>(). StopSpawningEnemy();
        GameOverPanel();
    }

    public void IncreaseScore()
    {
        if(!isGameOver)
        {
            score++;
            DisplayScore();
        }
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    void GameOverPanel()
    {
        gameoverPanel.SetActive(true);
    }

    private void ButtonsWorkings()
    {
        restartBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game1");
        });

        MenuBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MM1");
        });
    }
}
