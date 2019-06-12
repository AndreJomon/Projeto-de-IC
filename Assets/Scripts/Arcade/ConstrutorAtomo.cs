using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstrutorAtomo : MonoBehaviour
{
    public List<DeafText> nome;
    public int cargaTotal;
    public int massaTotal;
    public int numProtons = 0;
    public int numEletrons = 0;
    public int numNeutrons = 0;
    public Text nomeText, cargaText, massaText;

    public int GetNumProtons()
    {
        return numProtons;
    }
    
    public void AddParticula(int carga, int massa)
    {
        AddCarga(carga);
        AddMassa(massa);
        UpdateUI();
    }

    public void RemoveParticula(int carga, int massa)
    {
        RemoveCarga(carga);
        RemoveMassa(massa);
        UpdateUI();
    }

    private void AddCarga(int carga)
    {
        cargaTotal += carga;
        if (carga > 0)
        {
            numProtons++;
        }
    }

    private void RemoveCarga(int carga)
    {
        cargaTotal -= carga;
        if (carga > 0)
        {
            numProtons--;
        }
    }

    private void AddMassa(int massa)
    {
        if (massa < 0)
            Warning();
        massaTotal += massa;
    }

    private void RemoveMassa(int massa)
    {
        if (massa < 0)
            Warning();
        massaTotal -= massa;
    }

    private void Warning()
    {
        Debug.Log("Essas funções esperam número positivos");
    }

    private void UpdateUI()
    {
        nomeText.text = nome[numProtons].text;
        nomeText.gameObject.GetComponent<PlayVideoOnMouseOver>().video = nome[numProtons].video;
        cargaText.text = cargaTotal.ToString();
        massaText.text = massaTotal.ToString();
    }
}
