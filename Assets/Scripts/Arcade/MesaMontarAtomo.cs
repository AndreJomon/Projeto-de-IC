using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaMontarAtomo : MonoBehaviour
{
    public List<string> tabelaPeriodica;
    private int cargaTotal = 0;
    private int numeroDeMassa = 0;
    private int elementoDaTabela = 0;


    public void AdicionandoParticula(int carga, int massa)
    {
        AdicionarCarga(carga);
        AdicionarMassa(massa);
    }

    public void RemovendoParticula(int carga, int massa)
    {
        RetirarCarga(carga);
        RetirarMassa(massa);
    }

    private void AdicionarMassa(int massa)
    {
        numeroDeMassa += massa;
    }

    private void RetirarMassa (int massa)
    {
        numeroDeMassa -= massa;
    }

    private void AdicionarCarga(int carga)
    {
        cargaTotal += carga;
        MudarElementoDaTabela(carga, true);
    }

    private void RetirarCarga(int carga)
    {
        cargaTotal -= carga;
        MudarElementoDaTabela(carga, false);
    }

    private void MudarElementoDaTabela(int carga, bool adicionando)
    {
        if (carga > 0)
        {
            if (adicionando)
            {
                elementoDaTabela++;
            }
            else
            {
                elementoDaTabela--;
            }
        }
    }

    private void Update()
    {
        Debug.Log(tabelaPeriodica[elementoDaTabela]);
        Debug.Log("Carga Total é:" + cargaTotal.ToString());
        Debug.Log("Massa atômica é:" + numeroDeMassa.ToString());
    }


}
