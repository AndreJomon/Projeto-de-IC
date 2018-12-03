using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private float letterPause = 0.03f;
    private bool instantText = false;

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
}
