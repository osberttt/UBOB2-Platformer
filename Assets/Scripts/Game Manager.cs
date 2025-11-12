using System;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    // persistent singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int apples;
    public int deaths;
}
