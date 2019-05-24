using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverSound : MonoBehaviour, IPointerEnterHandler
{
    AudioClip mouseOverSound;
    AudioClip clickSound;
    UnityEngine.UI.Button botao;    

    private void Start()
    {
        mouseOverSound = (AudioClip)Resources.Load("Sounds/sfx/mouseOver");
        clickSound = (AudioClip)Resources.Load("Sounds/sfx/clickSound");
        botao = GetComponent<UnityEngine.UI.Button>();

        botao.onClick.AddListener(delegate () { SoundManager.instance.PlaySFX(clickSound); });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.instance.PlaySFX(mouseOverSound);
    }
}
