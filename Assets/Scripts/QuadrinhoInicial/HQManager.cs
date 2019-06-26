using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQManager : MonoBehaviour
{
    public Animator animator;

    public void ToggleOff(GameObject item)
    {
        item.SetActive(false);
    }

    public void ToggleOn(GameObject item)
    {
        item.SetActive(true);
    }

    public void SetHQTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    public void PlayVideo(GameObject videoContainer)
    {
        StartCoroutine(VideoManager.instance.PlayVideo(videoContainer.GetComponent<PlayVideoOnMouseOver>().video));
    }

    public void RestartVideo()
    {
        VideoManager.instance.ReplayVideo();
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
