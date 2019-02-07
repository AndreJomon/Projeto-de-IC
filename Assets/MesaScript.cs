using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaScript : MonoBehaviour {

    private List<List<string>> respostasCertas = new List<List<string>>();
    [Tooltip("Moleculas a serem colocadas, os atomos devem ser separados em ' '")]
    public List<string> moleculas;
    private int numeroDeRespostasCertas;
    public List<string> resposta = new List<string>();

    void Awake()
    {
        numeroDeRespostasCertas = moleculas.Count;
        for (int i = 0; i < numeroDeRespostasCertas; i++)
        {
            respostasCertas.Add(new List<string>());
        }

        OrganizaMolecula();
    }

    /// <summary>
    /// Manda cada molécula para o ColocoMolecula na Lista
    /// </summary>
    void OrganizaMolecula()
    {
        moleculas.Sort();

        for (int i = 0; i< numeroDeRespostasCertas; i++)
        {
            ColocaMoleculaNaLista(moleculas[i], i);
        }
    }

    /// <summary>
    /// Adiciona na lista de strings a molecula X na posição Y
    /// </summary>
    /// <param name="moleculaRecebida">Molecula X</param>
    /// <param name="index">Molecula Y</param>
    void ColocaMoleculaNaLista(string moleculaRecebida, int index)
    {
        moleculaRecebida = moleculaRecebida.ToUpper();
        string[] atomos = moleculaRecebida.Split(' ');
        foreach (string atomo in atomos)
        {
            respostasCertas[index].Add(atomo);
        }
        respostasCertas[index].Sort();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrou");
        resposta.Add(collision.GetComponent<Atomo>().nome);
        Debug.Log(resposta.Count);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        resposta.Remove(collision.GetComponent<Atomo>().nome);
        Debug.Log(resposta.Count);
    }

    public void rerere()
    {
        RespostaPossivel();
    }

    public bool RespostaPossivel()
    {
        resposta.Sort();

        foreach (List<string> molecula in respostasCertas)
        {
            if (CompareList(molecula, resposta))
            {
                Debug.Log(true);
                return true;
            }
        }
        Debug.Log(false);
        return false;
    }

    public bool CompareList(List<string> lista1, List<string> lista2)
    {
        if (lista1.Count != lista2.Count)
        {
            return false;
        }

        for (int i = 0; i<lista1.Count; i++)
        {
           if (!lista1[i].Equals(lista2[i]))
            {
                return false;
            }
        }

        return true;
    }
}
