using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class TextBox : MonoBehaviour {

    private string textString; //Recebe string
    private int lineHeight = 17; //Espaço para caber mais uma linha
    private int lineWidth = 33; //Numero de caracters em uma linha
    private float finalHeight; //Altura que será calculada
    private int secondsUntilDestroy = 5;
    public bool dontAutomaticDestroy = false;
    public VideoClip videoClip;

    #region Initializers

    /// <summary>
    /// Utilizado para criar uma textBox na posição dada, retorna o gameObject instanciado.
    /// </summary>
    /// <param name="text">Texto que estará dentro da caixa de texto</param>
    /// <param name="position">Posição para instanciar</param>
    /// <returns>textBox Instanciado</returns>
    public static GameObject CreateTextBox(string text, int time, Vector3 position)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text = text;
        textBox.GetComponent<TextBox>().SetAutoDestroyTime(time);
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    public static GameObject CreateTextBox(string text, Vector3 position)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text= text;
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    public static GameObject CreateTextBox(string text, Vector3 position, VideoClip clip)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text = text;
        textBox.GetComponent<TextBox>().videoClip = clip;
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    public static GameObject CreateTextBox(string text, int time, Vector3 position, VideoClip clip)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text = text;
        textBox.GetComponent<TextBox>().SetAutoDestroyTime(time);
        textBox.GetComponent<TextBox>().videoClip = clip;
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    public static GameObject CreateTextBox(string text, Vector3 position, bool dontAutomaticDestroy)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text = text;
        textBox.GetComponent<TextBox>().dontAutomaticDestroy = dontAutomaticDestroy;
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    public static GameObject CreateTextBox(string text, Vector3 position, VideoClip clip, bool dontAutomaticDestroy)
    {
        GameObject textBox = Resources.Load("Prefabs/TextBox") as GameObject;
        textBox.GetComponentInChildren<Text>().text = text;
        textBox.GetComponent<TextBox>().videoClip = clip;
        textBox.GetComponent<TextBox>().dontAutomaticDestroy = dontAutomaticDestroy;
        textBox = Instantiate(textBox, position, Quaternion.identity, GameObject.Find("Canvas").transform);
        return textBox;
    }

    #endregion

    /// <summary>
    /// Para tocar o video de auxílio, caso exista.
    /// </summary>
    private void OnMouseEnter()
    {
        if (videoClip != null)
        {
            VideoManager videoManager;
            videoManager = VideoManager.instance;
            videoManager.PlayVideo(videoClip);
        }
    }

    public void Awake()
    {
        textString = gameObject.GetComponentInChildren<Text>().text;
        int numberOfLines = NecessaryLines(textString.Length);
        finalHeight = numberOfLines * lineHeight;
        FixHeight();
        if (!dontAutomaticDestroy)
        {
            StartCoroutine(DestroyTextBox());
        }
    }

    #region AwakeHelpFunctions
    /// <summary>
    /// Coloca a altura necessária no texto e na caixa para que o texto não saia de nenhum dos dois.
    /// </summary>
    private void FixHeight()
    {
        FixTextHeight();
        FixBoxHeight();
    }

    /// <summary>
    /// Mexe na altura da caixa de texto
    /// </summary>
    private void FixTextHeight()
    {
        GameObject textGameObject = gameObject.transform.GetChild(0).gameObject;
        RectTransform rt = textGameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, finalHeight);
    }

    /// <summary>
    /// Mexe na altura do sprite da caixa de texto
    /// </summary>
    private void FixBoxHeight()
    {
        GameObject textGameObject = gameObject.transform.GetChild(1).gameObject;
        RectTransform rt = textGameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, finalHeight);
    }

    /// <summary>
    /// Calcula o número de linhas necessárias de acordo com o número de palavras na string (não considera os /n)
    /// </summary>
    /// <param name="numberWords"></param>
    /// <returns>Número de linhas que aquela quantidade de caracteres irá ocupar.</returns>
    private int NecessaryLines(int numberWords)
    {
        return Mathf.CeilToInt((float)numberWords / (float)lineWidth);
    }

    #endregion

    #region DestroyObjectFunction
    /// <summary>
    /// Coloca tempo para o objeto sumir
    /// </summary>
    /// <param name="time"></param>
    public void SetAutoDestroyTime(int time)
    {
        if (secondsUntilDestroy == 5)
        {
            secondsUntilDestroy = time;
        }
    }

    /// <summary>
    /// Destrói a partir do tempo dado (o normal é 5s) a caixa de texto
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyTextBox()
    {
        Animator animator = this.GetComponent<Animator>();
        yield return new WaitForSeconds(secondsUntilDestroy - 1); // 1 = Tempo da animação
        Debug.Log(secondsUntilDestroy - 1);
        animator.Play("TextBoxDisappearing");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    #endregion
}