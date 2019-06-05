using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryPrefabSelfManager : MonoBehaviour
{
    public UnityEngine.UI.Text headerText;
    public UnityEngine.UI.Text contentText;

    public void Toggle(bool value)
    {
        gameObject.SetActive(value);
    }

    public void StopVideo()
    {
        VideoManager.instance.StopVideo();
    }

    public void StartContentVideo(GameObject content)
    {
        StartCoroutine(VideoManager.instance.PlayVideo(content.GetComponent<PlayVideoOnMouseOver>().video));
    }

    public void UpdatePrefabs(GlossaryElement glossaryElement)
    {
        headerText.text = glossaryElement.expression;
        headerText.GetComponent<PlayVideoOnMouseOver>().video = glossaryElement.expressionVideo;
        contentText.text = glossaryElement.meaning;
        contentText.GetComponent<PlayVideoOnMouseOver>().video = glossaryElement.meaningVideo;
    }
}
