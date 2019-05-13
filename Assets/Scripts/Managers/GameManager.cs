using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private float letterPause = 0.03f;
    private bool instantText = false;
    public GameObject ballonTips;

    #region Loader
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeManagers()
    {
        GameObject gameManager, saveManager, videoManager;

        gameManager = Resources.Load("Prefabs/Managers/GameManager") as GameObject;

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        saveManager = Resources.Load("Prefabs/Managers/SaveManager") as GameObject;

        if (SaveManager.instance == null)
        {
            Instantiate(saveManager);
        }

        videoManager = Resources.Load("Prefabs/Managers/VideoManager") as GameObject;

        if (VideoManager.instance == null)
        {
            Instantiate(videoManager);
        }
    }
    #endregion

    public void SetLetterPause(float letterPause)
    {
        this.letterPause = letterPause;
    }

    public float GetLetterPause()
    {
        return letterPause;
    }

    public void SetInstantText(bool instantText)
    {
        this.instantText = instantText;
    }

    public bool GetInstantText()
    {
        return instantText;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnApplicationQuit()
    {
        SaveManager.instance.Save();
    }
}
