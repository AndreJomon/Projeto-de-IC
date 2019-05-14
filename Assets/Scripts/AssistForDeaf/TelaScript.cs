using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TelaScript : MonoBehaviour
{
    private VideoManager videoManager;
    [SerializeField]
    private Texture videoClip, pauseScreen, replayScreen;

    public void Start()
    {
        videoManager = VideoManager.instance;
        StartCoroutine(ReplayScreenAppear());
    }

    public void OnMouseDown()
    {
        if (videoManager.VideoIsPlaying())
        {
            videoManager.PauseVideo();
            videoClip = GetComponent<RawImage>().texture;
            GetComponent<RawImage>().texture = pauseScreen;
        }

        else
        {
            if (videoManager.VideoEnded())
            {
                GetComponent<RawImage>().texture = videoClip;
                videoManager.ReplayVideo();
                StartCoroutine(ReplayScreenAppear());
            }

            else
            {
                GetComponent<RawImage>().texture = videoClip;
                StartCoroutine(videoManager.PlayVideo());
                Debug.Log("Entrou aqui");
            }
        }
    }

    private IEnumerator ReplayScreenAppear()
    {
        yield return new WaitUntil(() => videoManager.VideoEnded());
        GetComponent<RawImage>().texture = replayScreen;
    }
}
