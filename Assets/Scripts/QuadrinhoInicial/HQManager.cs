using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQManager : MonoBehaviour
{
    public Animator animator;
    private bool holdAnimation = true;

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
    
    public void DisableChild()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void FimQuadrinho()
    {
        LoadScene.SceneLoader("Lousa");
    }

    public void PlayDelayedVideo(GameObject videoContainer)
    {
        StartCoroutine(PlayAfterDelay(videoContainer));
    }

    public IEnumerator PlayAfterDelay(GameObject videoContainer)
    {
        yield return new WaitUntil(() => !holdAnimation);
        PlayVideo(videoContainer);
        RestartVideo();
        holdAnimation = true;
    }

    public void HoldAnimation()
    {
        holdAnimation = false;
    }
}
