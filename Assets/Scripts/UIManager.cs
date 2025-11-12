using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
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
}
