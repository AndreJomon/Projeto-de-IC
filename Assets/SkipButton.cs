using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkipButton : MonoBehaviour {

    Text learnText;
    GameObject ballonText;

    private void Awake()
    {
        learnText = GameObject.FindGameObjectWithTag("LearnText").GetComponent<Text>();
        ballonText = GameObject.FindGameObjectWithTag("BallonText");
    }
}
