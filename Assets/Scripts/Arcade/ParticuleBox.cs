using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleBox : MonoBehaviour
{
    public GameObject particule;
    private GameObject newParticule;
    private int distance = 10;
    private static int qtdProton = 0;
    private static int qtdEletron = 0;
    private static int qtdNeutron = 0;

    private void OnMouseDown()
    {
        InstanciarNovaParticula();
    }

    private void InstanciarNovaParticula()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        newParticule = Instantiate(particule, mousepos, Quaternion.identity);
    }

    private void OnMouseDrag()
    {
        if (!GameObject.FindGameObjectWithTag("Particule"))
        {
            //newParticule.GetComponent<Particule>().OnMouseDrag();
        }
    }

    public static void AlterarQntdParticula(int valor, int carga)
    {
        switch (carga)
        {
            case 0:
                qtdNeutron += valor;
                break;
            case 1:
                qtdProton += valor;
                break;
            case -1:
                qtdEletron += valor;
                break;
        }
    }
}