using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        /*if (PlayerPrefs.HasKey("Deaths"))
        {
            PlayerPrefs.SetInt("Deaths", 4);
        }*/
        var deaths = PlayerPrefs.GetInt("Deaths", 0);
        PlayerPrefs.SetInt("Deaths", deaths + 1);
        Debug.Log(PlayerPrefs.GetInt("Deaths", 0));
    }
}
