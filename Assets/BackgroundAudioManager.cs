using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAudioManager : MonoBehaviour
{
    public Button buttonMusic;
    public Button buttonNoMúic;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalControl.Instance.isBackgroundMusicPlaying)
        {
            audioSource.Play();
        } else
        {
            buttonMusic.gameObject.SetActive(false);
            buttonNoMúic.gameObject.SetActive(true);
            audioSource.Stop();
        }
    }

    public void TurnOnOffBackgroundAudio(bool isActive)
    {
        if (isActive)
        {
            audioSource.Play();
            GlobalControl.Instance.isBackgroundMusicPlaying = true;
        } else
        {
            audioSource.Stop();
            GlobalControl.Instance.isBackgroundMusicPlaying = false;
        }
    }
}
