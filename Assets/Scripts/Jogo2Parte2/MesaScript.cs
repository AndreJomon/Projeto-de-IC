using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<string> moleculaCertaTemp; //String colocada no inspector, que serão utilizadas para montar a lista moleculaCerta
    public List<string> resposta = new List<string>(); //Lista que é montada a cada novo átomo que o usuário adiciona
    public string errouString; //Mensagem de erro ao não conseguir montar uma molécula válida e clicar em "Montar molécula"
    private GameObject moleculaAtual; //molecula que está montada na mesa
    private List<Molecula> moleculaCerta; //Lista de moléculas corretas
    private Animator brilho; //Animator da animação de brilho ao concluir níveis
    private Button colocarNoBalaoButton; //Botão de enviar a molécula para outra tela

    void Awake()
    {
        OrganizaListaMolecula();
        brilho = GameObject.Find("Brilho").GetComponent<Animator>();
        colocarNoBalaoButton = GameObject.Find("EnviarButton").GetComponent<Button>();
    }

    void OrganizaListaMolecula()
    {
        moleculaCerta = new List<Molecula>();

        for (int i = 0; i<moleculaCertaTemp.Count; i++)
        {
            moleculaCerta.Add(new Molecula(moleculaCertaTemp[i], i)); //Utiliza o construtor da classe Molécula
        }
    }

    /// <summary>
    /// Checa se a resposta é válida ou não e faz o output desejado
    /// </summary>
    public void ChecarResposta()
    {
        int respostaAtual = RespostaPossivel(); //Verifica se a resposta é possível e recebe o index, caso a resposta seja permitda
        if (respostaAtual >= 0) //Acertou a resposta
        {
            StartCoroutine(AcertouResposta(respostaAtual)); //Começa a coroutine caso acerte a resposta
            colocarNoBalaoButton.interactable = true;
        }
        else //Errou a resposta
        {
           TextBox.CreateTextBox(errouString, GameObject.Find("PontoParaAviso").transform.position); //Cria um aviso de erro*/
        }
    }

    #region Funções Auxiliares do ChecarResposta()
    /// <summary>
    /// Verifica se a resposta é possível e retorna o indíce da resposta, caso não seja, retorna -1
    /// </summary>
    /// <returns></returns>
    public int RespostaPossivel()
    {
        resposta.Sort(); //Organiza a lista da resposta, para que fique na mesma ordem da lista das moleculas permitidas

        foreach (Molecula respostaCerta in moleculaCerta) //Para cada molecula da lista de moleculas permitidas, verifica se a resposta é igual a ela
        {
            if (CompareList(respostaCerta.atomos, resposta))
            {
                return respostaCerta.GetIndex(); //Retorna o indíce da resposta certa (que é igual ao indíce que está no inspetor)
            }
        }
        return -1;
    }

    /// <summary>
    /// Compara duas listas de strings para ver se são iguais.
    /// </summary>
    /// <param name="lista1"></param>
    /// <param name="lista2"></param>
    /// <returns></returns>
    public bool CompareList(List<string> lista1, List<string> lista2)
    {
        if (lista1.Count != lista2.Count)
        {
            return false;
        }

        for (int i = 0; i < lista1.Count; i++)
        {
            if (!lista1[i].Equals(lista2[i]))
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    /// <summary>
    /// Troca a imagem dos átomos pela imagem da molécula montada e ativa uma animação de transição entre os dois estados.
    /// </summary>
    /// <param name="respostaAtual"></param>
    /// <returns></returns>
    private IEnumerator AcertouResposta(int respostaAtual)
    {
        moleculaAtual = Resources.Load(string.Concat("Prefabs/Jogo2Parte2/Molecula/molecula", respostaAtual.ToString())) as GameObject; //Carrega prefab da molecula que foi criada
        brilho.Play("Brilho");
        yield return new WaitForSeconds(0.4f);
        LimparAtomo();
        GameObject newMolecula = Instantiate(moleculaAtual/*, GameObject.Find("Canvas").transform*/);
        newMolecula.transform.position = GameObject.Find("Mesa(Image)").transform.position;
    }

    /// <summary>
    /// Destrói todos os átomos da tela
    /// </summary>
    private void LimparAtomo()
    {
        GameObject[] atomos = GameObject.FindGameObjectsWithTag("Atomo");
        foreach (GameObject atomo in atomos)
        {
            Destroy(atomo);
        }
    }

    /// <summary>
    /// Destrói todas moléculas da tela
    /// </summary>
    private void LimparMolecula()
    {
        GameObject[] moleculas = GameObject.FindGameObjectsWithTag("Molecula");
        moleculaAtual = null;
        foreach (GameObject molecula in moleculas)
        {
            Destroy(molecula);
        }

    }

    /// <summary>
    /// Envia a resposta para a scene dos balões e vai para ela
    /// </summary>
    public void MandarResposta()
    {
        Pot.PutOnPot(moleculaAtual, Pot.currentPot);
        LoadScene.SceneLoader("Encher Balões");
    }

    /// <summary>
    /// Toca uma animação e deleta todas moléculas e átomos na tela
    /// </summary>
    /// <returns></returns>
    public IEnumerator LimparResposta()
    {
        brilho.Play("Brilho");
        yield return new WaitForSeconds(0.4f);
        LimparMolecula();
        LimparAtomo();
    }

    /// <summary>
    /// Função do botão Limpar Resposta, chama a coroutine que faz isso
    /// </summary>
    public void LimparRespostaButton()
    {
        StartCoroutine(LimparResposta());
        colocarNoBalaoButton.interactable = false;
    }
}
