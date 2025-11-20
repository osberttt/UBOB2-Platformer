using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // persistent singleton
    public static AudioManager instance;

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

    public AudioSource musicSource;
    public GameObject sfxSourcePrefab;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip, float volume = 0.5f)
    {
        var sfxSourceObj = Instantiate(sfxSourcePrefab, transform);
        var sfxSource = sfxSourceObj.GetComponent<AudioSource>();
        sfxSource.volume = volume;
        sfxSource.PlayOneShot(clip);
        Destroy(sfxSourceObj, clip.length);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ResumeMusic()
    {
        musicSource.Play();
    }
}
