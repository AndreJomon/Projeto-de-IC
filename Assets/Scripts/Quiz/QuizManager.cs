using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    private int score;
    [SerializeField] private int dificulty;
    [SerializeField] private int qtyQuestionsToDo;
    public Perguntas[] questionGroup;

    public QuizManager instance;
    [SerializeField] private List<QuestionAndAnswer> questionAndAnswer;
    [SerializeField] private List<int> numbersList;

    public TextMeshProUGUI questionMeshText;
    public TextMeshProUGUI[] answerMeshText;

    private int index;

    public void SetDificulty(int value)
    {
        dificulty = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        questionAndAnswer = new List<QuestionAndAnswer>();
        RestartNumberList();
        PrepareNewQuestion();
    }

    /// <summary>
    /// Função que prepara a nova pergunta que será utilizada no quiz. Responsável por selecionar a pergunta que será utilizada da 
    /// lista e de adicionar na lista de perguntas que já foram utilizadas.
    /// </summary>
    public void PrepareNewQuestion()
    {
        index = questionAndAnswer.Count;

        questionAndAnswer.Add(new QuestionAndAnswer());
        questionAndAnswer[index].SetDificultyLevel(dificulty);

        int questionSelected = RandomQuestionNumber();
        questionAndAnswer[index].SetQuestionNumber(questionSelected);
        Debug.Log("Questão selecionada foi: " + questionSelected);

        ShowNewQuestion();
    }

    public void ShowNewQuestion()
    {
        Pergunta selectedQuestion = questionGroup[dificulty].GetQuestion(questionAndAnswer[index].GetQuestionNumber());
        questionMeshText.text = selectedQuestion.GetQuestion().text;

        for (int i = 0; i < 4; i++)
        {
            answerMeshText[i].text = selectedQuestion.GetAlternative(i).text;
        }
    }

    #region Funções Auxiliares
    /// <summary>
    /// Função que seleciona um número aleatório da lista de perguntas que ainda não foram realizadas
    /// </summary>
    /// <returns></returns>
    public int RandomQuestionNumber()
    {
        /// Seleciona o número aleatório
        int numberSelected = numbersList[Random.Range(0, numbersList.Count)];
        /// Remove da lisata para não ser selecionado novamente
        numbersList.Remove(numberSelected);
        /// Retorna o valor selecionado
        return numberSelected;
    }
    
    /// <summary>
    /// Função que reseta a lista de questões que podem ser utilizadas. Esta lista contém o número das queestões apenas
    /// </summary>
    private void RestartNumberList()
    {
        numbersList = new List<int>();

        for (int i = 0; i < questionGroup[dificulty].GetLenght(); i++)
        {
            numbersList.Add(i);
        }
    }
    #endregion
}