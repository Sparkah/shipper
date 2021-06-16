using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    public GameObject Play;
    public GameObject Reset;
    public GameObject Pause;
    public GameObject BackGroundImg;
    public PlayerMover playerMover;
    public GameObject PauseMenuImg;
    public Text LevelNum;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGameBtn()
    {
        playerMover.PlayGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuImg.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuImg.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        PauseMenuImg.SetActive(false);
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

    public void ResetGame()
    {
        playerMover.ResetList();
    }

    private void Update()
    {
        LevelNum.text = "Уровень: " + SceneManager.GetActiveScene().buildIndex;
    }
}