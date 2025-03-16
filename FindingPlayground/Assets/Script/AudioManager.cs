using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Sources-------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip-------")]
    public AudioClip background;
    public AudioClip lose;
    public AudioClip win;
    public AudioClip jump;
    public AudioClip collect;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        //keep playing the music
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
