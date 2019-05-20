using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampScript : MonoBehaviour
{
    /// <summary>
    /// Cor utilizada para as dicas.
    /// </summary>
    public string colorCode;
    private string colorCodeEnd = "</color>";
    /// <summary>
    /// Palavras que possuem alguma dica relacionada a elas.
    /// </summary>
    [Tooltip("Palavras que possuem uma explicação")]
    [SerializeField]
    private List<KeyWord> notoriousWord;
    /// <summary>
    /// Curiosidades mostradas após o texto passar.
    /// </summary>
    [SerializeField]
    public List<KeyWord> curiosity;
    /// <summary>
    /// Curiosidade que será mostrada caso o jogador clique na lâmpada
    /// </summary>
    public KeyWord currentCuriosity;
    /// <summary>
    /// Booleano que diz ser a luz está ligada ou desligada
    /// </summary>

    public Animator anim;
    private GameManager gameManager;
    private VideoManager videoManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        AdjustLetters();
    }

    /// <summary>
    /// Ajusta as notoriousWord para que elas ganhem o código que mostra a cor do texto.
    /// </summary>
    private void AdjustLetters()
    {
        foreach (KeyWord kw in notoriousWord)
        {
            kw.name = (colorCode + kw.name + colorCodeEnd);
        }
    }

    /// <summary>
    /// Toca a animação de que existe uma curiosidade disponível
    /// </summary>
    /// <param name="word">Palavra-chave da curiosidade (nome)</param>
    public void TurnOnLamp(string word)
    {
        int wordIndex = SearchIndexKeyWord(curiosity, word);

        if (wordIndex != -1)
        {
            currentCuriosity = curiosity[wordIndex];
            anim.SetBool("lightOn", true);
            GetComponent<Button>().interactable = true;
        }
    }

    /// <summary>
    /// O que acontece quando se clica na lâmpada após ela estar ativa
    /// </summary>
    public void ClickOnTurnedOnLamp()
    {
        gameManager.CreateBallonText(currentCuriosity.text);
        anim.SetBool("lightOn", false);
    }

    /// <summary>
    /// Função que deve ser chamada pela função de passar o mouse em cima das palavras
    /// </summary>
    /// <param name="word"></param>
    public void NotoriousWordAppear(string word)
    {
        int wordIndex = SearchIndexKeyWord(notoriousWord, word);

        if (wordIndex != -1)
        {
            gameManager.CreateBallonText(notoriousWord[wordIndex].text);
        }
    }

    public void NotoriousWordAppearOnClick(string word)
    {
        int wordIndex = SearchIndexKeyWord(notoriousWord, word);

        if (wordIndex != -1)
        {
            videoManager = VideoManager.instance;
            StartCoroutine(videoManager.PlayVideoHelper(notoriousWord[wordIndex].video));
        }
    }

    /// <summary>
    /// Procura o index da palavra chama na lista de KeyWord dada
    /// </summary>
    /// <param name="kwList">Lista de Keyword</param>
    /// <param name="searchedWord">Palavra que está sendo procurada</param>
    /// <returns>Index da palavra dentro da lista</returns>
    public int SearchIndexKeyWord(List<KeyWord> kwList, string searchedWord)
    {
        searchedWord = searchedWord.ToUpper();
        foreach (KeyWord kw in kwList)
        {
            if (kw.name.ToUpper().Equals(searchedWord))
            {
                return kwList.IndexOf(kw);
            }
        }

        return -1;
    }

    ///TODO: Funções para dicas sobre palavras estranhas
}
