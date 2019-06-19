using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualStyleChoicer : MonoBehaviour
{
    public GameObject imagemNeutra;
    public GameObject imagemAtualizada;
    public int flagAtiva;
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = SaveManager.instance;
        if (saveManager.player.GetBeatPartStatus(flagAtiva))
        {
            imagemAtualizada.SetActive(true);
            imagemNeutra.SetActive(false);
        }
        else
        {
            imagemAtualizada.SetActive(false);
            imagemNeutra.SetActive(true);
        }
    }
}
