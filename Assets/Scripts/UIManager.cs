using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public TextMeshProUGUI totalApplesText;
    public TextMeshProUGUI totalDeathsText;
    public TextMeshProUGUI applesinLevelText;
    public GameObject gameOverPanel;
    
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        applesinLevelText.text = AppleManager.instance.AppleCount();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Win()
    {
        victoryPanel.SetActive(true);
        totalApplesText.text = GameManager.instance.apples.ToString();
        totalDeathsText.text = GameManager.instance.deaths.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void SetAppleCount(string count)
    {
        applesinLevelText.text = count;
    }
}
