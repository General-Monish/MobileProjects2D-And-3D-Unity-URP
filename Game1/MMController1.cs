using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MMController1 : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game1");
        });
        playBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
