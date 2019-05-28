using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlay : MonoBehaviour
{
    SoundManager soundManager;
    public AudioClip menuMusic;

    void Awake()
    {
            soundManager = SoundManager.instance;
            soundManager.PlayBackgroundMusic(menuMusic);
            soundManager.ChangeBackgroundVolume(0.45f);
    }
}
