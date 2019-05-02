using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuintalSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] screen;
    private int currentScreen;

    public void ResetScreenPosition(GameObject screen)
    {
        screen.transform.position = new Vector3(0, 0, 0);
    }
}
