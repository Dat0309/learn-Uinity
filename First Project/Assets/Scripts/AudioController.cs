using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float soundVolume;

    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip[] backgroundMusics;
    public AudioClip rightSounud;
    public AudioClip loseSound;
    public AudioClip winSound;

    private void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicAus && soundAus)
        {
            musicAus.volume = musicVolume;
            soundAus.volume = soundVolume;
        }
    }

    public void PlayBackgroundMusic()
    {
        if(musicAus && backgroundMusics != null && backgroundMusics.Length > 0)
        {
            int rand = Random.Range(0, backgroundMusics.Length);
            if (backgroundMusics[rand])
            {
                musicAus.clip = backgroundMusics[rand];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if (soundAus && sound)
        {
            soundAus.volume = soundVolume;
            soundAus.PlayOneShot(sound);
        }

    }

    public void PlayRightSound()
    {
        PlaySound(rightSounud);
    }

    public void LoseSound()
    {
        PlaySound(loseSound);
    }

    public void WinSound()
    {
        PlaySound(winSound);
    }

    public void StopMusic()
    {
        if (musicAus)
            musicAus.Stop();
    }

    public void MakeSingleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
