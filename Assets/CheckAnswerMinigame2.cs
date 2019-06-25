using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswerMinigame2 : MonoBehaviour
{
    public float time;
    private List<GameObject> potContent;
    private List<string> listOfMolecules; ///Serve para saber se alguma molécula já foi contada

    private void Start()
    {
        potContent = Pot.GetPots();
        ActiveButton();
    }

    private void OnClick()
    {
        int numberOfMolecules = 0;
        for (int i = 0; i < potContent.Count; i++) {
            if (potContent[i] != null)
            {
                MoleculaMinigame2 moleculaInfo = potContent[i].GetComponent<MoleculaMinigame2>();

                if (!listOfMolecules.Contains(moleculaInfo.name))
                {
                    listOfMolecules.Add(moleculaInfo.name);
                    numberOfMolecules++;
                    /// moleculaInfo.points; Dar em algum lugar essa pontuação.
                    /// Toca animação do bagulho
                }
            }
        }

        if (numberOfMolecules > 2)
        {
            SaveManager.instance.player.SetBeatPartTrue(2);
        }
        ///Instancia um feedback talvez
        ///
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        GetComponent<LoadScene>().SceneLoaderForButtons("EscolhaDeFase");
    }

    private void ActiveButton()
    {
        Debug.Log(potContent.Count);
        for (int i = 0; i < potContent.Count; i++)
        {
            if (potContent[i] != null)
            {
                gameObject.GetComponent<Button>().interactable = true;
                return;
            }
        }
    }
}
