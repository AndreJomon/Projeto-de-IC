using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloassaryTest : MonoBehaviour
{
    public List<GlossaryInfo> glossaryList;


    public void SortTest(string find)
    {
        Debug.LogWarning("Lista original");
        foreach (GlossaryInfo g in glossaryList)
        {
            Debug.Log(g.termo);
        }

        List<GlossaryInfo> temp = glossaryList;
        temp.Sort(delegate (GlossaryInfo a, GlossaryInfo b)
        {
            return a.termo.CompareTo(b.termo);
        });

        Debug.LogWarning("Lista organizada");
        foreach(GlossaryInfo g in temp)
        {
            Debug.Log(g.termo);
        }

        List<GlossaryInfo> searchResult = temp.FindAll(delegate (GlossaryInfo g)
        {
            if (g.termo.Contains(find)) return true;
            else return false;
        });

        Debug.LogWarning("Resultado da busca");
        foreach(GlossaryInfo g in searchResult)
        {
            Debug.Log(g.termo);
        }
    }

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
}

[System.Serializable]
public struct GlossaryInfo
{
    public string termo;
    public string significado;
}