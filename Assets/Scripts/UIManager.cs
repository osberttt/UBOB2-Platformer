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

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Next()
    {
        SceneManager.LoadScene("Level 2");
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

    public void SetAppleCount(int count)
    {
        applesinLevelText.text = count.ToString();
    }
}
