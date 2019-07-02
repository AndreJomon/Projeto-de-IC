using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMute : MonoBehaviour
{
    private SoundManager soundManager;
    private Image soundOff;

    private void Awake()
    {
        soundManager = SoundManager.instance;
        soundOff = GameObject.Find("SoundOffImage").GetComponentInChildren<Image>();
        soundOff.enabled = false;
    }

    public void Start()
    {
        if (/*soundManager.IsBackgroundPlaying() &&*/ !soundManager.IsBackgroundMuted())
        {
            soundOff.enabled = false;
        }
        else
        {
            soundOff.enabled = true;
        }
    }

    public void MuteAudio()
    {
        if (!soundManager.IsBackgroundMuted())
        {
            soundManager.MuteBackgroundMusic();
            soundManager.MuteSFX();
            soundOff.enabled = true;
        }
        else
        {
            soundManager.UnMuteBackgroundMusic();
            soundManager.UnMuteSFX();
            soundOff.enabled = false;
        }
    }
}
