using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class AtomBox : MonoBehaviour {

    private VideoManager videoManager;
    public GameObject atomo;
    private GameObject newAtomo;
    public VideoClip video;
    private int numAtomos;
    private int distance;

    private void Start()
    {
        videoManager = VideoManager.instance;
    }

    private void OnMouseEnter()
    {
        RawImage tela = GameObject.Find("Tela").GetComponent<RawImage>();
        StartCoroutine(videoManager.PlayVideo(tela, video));
    }

    void OnMouseDown()
    {
        InstanciarNovoAtomo();
    }

    private void InstanciarNovoAtomo()
    {
        if (Atomo.nAtomos <= 5 && !GameObject.FindGameObjectWithTag("Molecula"))
        {
            newAtomo = Instantiate(atomo, new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance), Quaternion.identity);
        }
    }


    private void OnMouseDrag()
    {
        if (Atomo.nAtomos <= 5 && !GameObject.FindGameObjectWithTag("Molecula"))
        {
            newAtomo.GetComponent<Atomo>().OnMouseDrag();
        }
    }

    private void OnMouseUp()
    {
        if (GameObject.FindGameObjectWithTag("Atomo"))
        {
            newAtomo.GetComponent<Atomo>().OnMouseUp();
        }
    }
}
