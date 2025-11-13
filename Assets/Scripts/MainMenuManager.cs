using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip uiClickedSfx;

    private void Start()
    {
        AudioManager.instance.PlayMusic(mainMenuMusic);
    }

    public void PlayButton()
    {
        // play sfx
        AudioManager.instance.PlaySfx(uiClickedSfx);
        // load level 1
        SceneManager.LoadScene("Level 1");
    }
}
