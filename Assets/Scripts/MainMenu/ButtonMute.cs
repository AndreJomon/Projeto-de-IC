using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMute : MonoBehaviour
{
    private SoundManager soundManager;
    private SpriteRenderer soundOff;

    private void Awake()
    {
        soundManager = SoundManager.instance;
        soundOff = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        if (soundManager.IsBackgroundPlaying() && !soundManager.IsBackgroundMuted())
        {
            soundOff.sortingOrder = -16;
        }
        else
        {
            soundOff.sortingOrder = 0;
        }
    }

    public void MuteAudio()
    {
        if (!soundManager.IsBackgroundMuted())
        {
            soundManager.MuteBackgroundMusic();
            soundManager.MuteSFX();
            soundOff.sortingOrder = 0;
        }
        else
        {
            soundManager.UnMuteBackgroundMusic();
            soundManager.UnMuteSFX();
            soundOff.sortingOrder = -16;
        }
    }
}
