using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        // load level 1
        SceneManager.LoadScene("Level 1");
    }
}
