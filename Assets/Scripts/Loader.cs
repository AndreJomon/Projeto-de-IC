using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    private GameObject videoManager, gameManager;

    private void Awake()
    {
        videoManager = Resources.Load("Prefabs/VideoManager") as GameObject;

        if (VideoManager.instance == null)
        {
            Instantiate(videoManager);
        }

        gameManager = Resources.Load("Prefabs/GameManager") as GameObject;

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    private void Start()
    {
        GameManager gameManager;
        gameManager = GameManager.instance;
    }
}
