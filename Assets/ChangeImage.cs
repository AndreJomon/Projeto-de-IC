using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public void SetImageGoHorse(Sprite image)
    {
        GetComponent<Image>().sprite = image;
    }
}
