﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class VideoManager : MonoBehaviour {

    public static VideoManager instance = null;
    private bool alreadyInstatiate = false;
    public VideoPlayer videoPlayer;
    private GameObject videoBox = null;
    private GameObject videoScreen;

    public void SetAlreadyInstatiate (bool alreadyInstatiate)
    {
        this.alreadyInstatiate = alreadyInstatiate;
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            videoBox = Resources.Load("Prefabs/VideoBox") as GameObject;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayVideo(Vector3 ballonTextPosition, VideoClip video)
    {
        videoPlayer.clip = video;
        if (!alreadyInstatiate)
        {
            videoBox = Instantiate(videoBox);
            alreadyInstatiate = true; //Não vai funcionar quando mudar de scene, melhor procurar se já existe o videoBox
        }
        videoBox.SetActive(true);
        videoBox.transform.position = ballonTextPosition;
        videoScreen = videoBox.transform.GetChild(0).gameObject;
        videoPlayer.targetMaterialRenderer = videoScreen.GetComponent<Renderer>();
        videoPlayer.Prepare();
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        videoBox.SetActive(false);
    }

    
}
