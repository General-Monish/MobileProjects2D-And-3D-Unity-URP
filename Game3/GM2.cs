using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM2 : MonoBehaviour
{
    public static GM2 instance;

    [HideInInspector]
    public bool isGameStarted = false;
    int lives = 2;
    int score = 0;
    Vector3 cameraPos;

    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject displayUI;
    [SerializeField] GameObject displayMenuUI;
    [SerializeField] GameObject obsSpawner;
    [SerializeField] GameObject particlePlayer;
    [SerializeField] GameObject particleBG;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cameraPos =  Camera.main.transform.position;
        livesText.text = "Lives: " + lives.ToString();
    }

    public void StartGame()
    {
        isGameStarted = true;
        particlePlayer.SetActive(true);
        particleBG.SetActive(true);
        displayMenuUI.SetActive(false);
        displayUI.SetActive(true);
        obsSpawner.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);
        Invoke("ReloadLevel", 1f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game3");
    }

    public void UpdateLives()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text ="Score: "+ score.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }

    IEnumerator CameraShake()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;
            Camera.main.transform.position = new Vector3(randomPos.x,randomPos.y,cameraPos.z);
            yield return null;
        }
        Camera.main.transform.position = cameraPos;
    }
}
