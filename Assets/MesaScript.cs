using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Molecula
{
    public string nome;
    private int index;
    public List<string> atomos;

    public Molecula(string atm, int index)
    {
        nome = atm;
        SetIndex(index);
        atomos = new List<string>();

        nome = nome.ToUpper();
        string[] atomosTemp = nome.Split(' ');
        foreach (string atomo in atomosTemp)
        {
            atomos.Add(atomo);
        }
        atomos.Sort();
    }

    public void SetIndex(int n)
    {
        index = n;
    }

    public int GetIndex()
    {
        return index;
    }
}

public class MesaScript : MonoBehaviour {

    [Tooltip("Moleculas a serem colocadas, os atomos devem ser separados em ' '")]
    public List<string> moleculaCertaTemp;
    public List<string> resposta = new List<string>();
    private List<Molecula> moleculaCerta;
    private Animator brilho;

    void Awake()
    {
        OrganizaListaMolecula();
        brilho = GameObject.Find("Brilho").GetComponent<Animator>();
    }

    /// <summary>
    /// Automaticamente colocas os index na lista de moleculas
    /// </summary>
    private void OrganizaIndex()
    {
        for (int i = 0; i< moleculaCerta.Count; i++)
        {
            moleculaCerta[i].SetIndex(i);
        }
    }

    /// <summary>
    /// Manda cada molécula para o ColocoMolecula na Lista
    /// </summary>
    void OrganizaListaMolecula()
    {
        moleculaCerta = new List<Molecula>();

        for (int i = 0; i<moleculaCertaTemp.Count; i++)
        {
            moleculaCerta.Add(new Molecula(moleculaCertaTemp[i], i));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        resposta.Add(collision.GetComponent<Atomo>().nome);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        resposta.Remove(collision.GetComponent<Atomo>().nome);
    }

    #region Botões

    public void ChecarResposta()
    {
        int numeroResposta = RespostaPossivel();
        if (numeroResposta >= 0)
        {
            StartCoroutine(AcertouResposta(numeroResposta));
        }
    }

    private IEnumerator AcertouResposta(int numeroResposta)
    {
        ///Animação para tampar a tela
        GameObject molecula = Resources.Load(string.Concat("Prefabs/Jogo2Parte2/Molecula/molecula", numeroResposta.ToString())) as GameObject;
        brilho.Play("Brilho");
        yield return new WaitForSeconds(0.4f);
        LimparAtomo();
        molecula = Instantiate(molecula, GameObject.Find("Canvas").transform);
        molecula.transform.position = GameObject.Find("Mesa(Sprite)").transform.position;
    }

    private void LimparAtomo()
    {
        GameObject[] atomos = GameObject.FindGameObjectsWithTag("Atomo");
        foreach (GameObject atomo in atomos)
        {
            Destroy(atomo);
        }
    }

    private void LimparMolecula()
    {
        GameObject[] moleculas = GameObject.FindGameObjectsWithTag("Molecula");
        foreach (GameObject molecula in moleculas)
        {
            Destroy(molecula);
        }

    }

    public void MandarResposta()
    {

    }

    public IEnumerator LimparResposta()
    {
        brilho.Play("Brilho");
        yield return new WaitForSeconds(0.4f);
        LimparMolecula();
        LimparAtomo();
    }

    public void LimparRespostaButton()
    {
        StartCoroutine(LimparResposta());
    }

    #endregion

    public int RespostaPossivel()
    {
        resposta.Sort();

        foreach (Molecula respostaCerta in moleculaCerta)
        {
            if (CompareList(respostaCerta.atomos, resposta))
            {
                return respostaCerta.GetIndex();
            }
        }
        return -1;
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
