using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private int correctAnswers = 0;
    [SerializeField] private int[] scoreIncrease;
    [SerializeField] private int dificulty = 0;
    [Tooltip("Quantidade total de perguntas que serão realizadas (máximo igual ao total de perguntas)")]
    [SerializeField] private int qtyQuestionsToDo;
    [SerializeField] private int qtyQuestionsDone;
    [Tooltip("ScriptableObject que contém as perguntas de uma determinada dificuldade")]
    public Perguntas[] questionGroup;

    public static QuizManager instance;
    [SerializeField] private List<QuestionAndAnswer> questionAndAnswer;
    [SerializeField] private List<int> numbersList;

    [Tooltip("GameObject que conterá o texto da pergunta")]
    public TextMeshProUGUI questionMeshText;
    [Tooltip("GameObject que conterá o texto da alternativa")]
    public TextMeshProUGUI[] answerMeshText;

    private int index;
    private int questionSelected;
    private int numberOfAnswers;

    public GameObject correctFeedback;
    public GameObject wrongFeedback;

    private TimeManager timeManager;

    #region Set/Get das variáveis
    public void SetDificulty(int value)
    {
        dificulty = value;
    }

    #endregion

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

        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();

        /// Cria uma lista de perguntas realizadas e respostas dadas pelo player
        questionAndAnswer = new List<QuestionAndAnswer>();

        /// Verifica se o número de perguntas a serem feitas é menor que o numero de perguntas existentes
        /// Caso seja maior, iguala ao total de perguntas
        if (qtyQuestionsToDo > questionGroup[dificulty].GetLenght())
        {
            qtyQuestionsToDo = questionGroup[dificulty].GetLenght();
        }

        /// Inicia a quantidade de questões feitas em zero
        qtyQuestionsDone = 0;

        /// Verifica quantas alternativas existem para cada pergunta
        numberOfAnswers = questionGroup[dificulty].GetQuestion(0).GetNumberOfAlternatives();

        /// Reinicia a lista de valores que podem ser sorteados
        RestartNumberList();

        SaveManager.instance.Load(3);// PARA TESTES

        /// Prepara uma nova pergunta para ser exibida
        PrepareNewQuestion();
    }

    /// <summary>
    /// Função que prepara a nova pergunta que será utilizada no quiz. Responsável por selecionar a pergunta que será utilizada da 
    /// lista e de adicionar na lista de perguntas que já foram utilizadas.
    /// </summary>
    public void PrepareNewQuestion()
    {
        /// Verifica se há mais questões a serem feitas ou se o quiz acabou
        if (qtyQuestionsDone < qtyQuestionsToDo)
        {
            /// Pega o indice da última posição da lista de perguntas e respostas já realizadas
            index = questionAndAnswer.Count;

            /// Adiciona uma nova posição na lista
            questionAndAnswer.Add(new QuestionAndAnswer());
            /// Salva a dificuldade da pergunta a ser feita
            questionAndAnswer[index].SetDificultyLevel(dificulty);

            /// Sorteia a pergunta dentre as possíveis da lista
            questionSelected = RandomQuestionNumber();
            /// Salva qual a pergunta que será realizada
            questionAndAnswer[index].SetQuestionNumber(questionSelected);
            /// Salva a data e hora que a pergunta foi selecionada
            questionAndAnswer[index].SetTime();

            //Debug.Log("Questão selecionada foi: " + questionSelected);

            /// Mostra a pergunta na tela
            ShowNewQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    /// <summary>
    /// Função que mostra a última pergunta sorteada na tela
    /// </summary>
    public void ShowNewQuestion()
    {
        /// Pega a pergunta que deve ser exibida da lista de perguntas
        Pergunta selectedQuestion = questionGroup[dificulty].GetQuestion(questionAndAnswer[index].GetQuestionNumber());
        /// Mostra a pergunta
        questionMeshText.text = selectedQuestion.GetQuestion().text;

        /// Mostra todas as alternativas
        for (int i = 0; i < numberOfAnswers; i++)
        {
            answerMeshText[i].text = selectedQuestion.GetAlternative(i).text;
        }

        UnblockButtons();
        
        timeManager.StartTimer();
    }

    /// <summary>
    /// Função que verifica se a resposta selecionada está correta e decide o que deve ser feito
    /// </summary>
    /// <param name="value"></param>
    public void CheckAnswer(int value)
    {
        BlockButtons();

        timeManager.EndTimer();

        StartCoroutine(VerifyAnswer(value));
    }

    /// <summary>
    /// Função que verifica a resposta e mostra o feedback
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private IEnumerator VerifyAnswer(int value)
    {
        /// Incrementa o contador de perguntas feitas
        qtyQuestionsDone++;
        /// Salva a alternativa escolhida
        questionAndAnswer[index].SetAnswerSelected(value);
        /// Verifica se a alternativa é a correta
        bool isCorrect = questionGroup[dificulty].GetQuestion(questionSelected).VerifyAnswer(value);

        /// Se for correta
        if (isCorrect)
        {
            /// Incrementa a pontuação e mostra o feedback positivo
            correctAnswers++;
            questionAndAnswer[index].SetIsCorrect(true);
            GameObject tempCorrectFeedback = Instantiate(correctFeedback, answerMeshText[value].transform.parent);
            yield return new WaitForSeconds(3f);
            Destroy(tempCorrectFeedback);
        }
        else /// Caso contrário
        {
            /// Mostra o feedback "negativo"
            questionAndAnswer[index].SetIsCorrect(false);
            if (value != -1)
            {
                GameObject tempCorrectFeedback = Instantiate(wrongFeedback, answerMeshText[value].transform.parent);
                yield return new WaitForSeconds(3f);
                Destroy(tempCorrectFeedback);
            }
        }

        Debug.Log("Resposta verificada");
        PrepareNewQuestion();
    }

    /// <summary>
    /// Função responsável pelas ações que devem ser realizadas quando o quiz acaba
    /// </summary>
    public void EndQuiz()
    {
        int scoreTemp = CalculateScore();
        if (scoreTemp >= SaveManager.instance.player.GetScore())
        {
            SaveManager.instance.player.SetQnA(questionAndAnswer);
            SaveManager.instance.player.SetScore(scoreTemp);
        }

        string tempMsg = "Você acertou " + correctAnswers + " de " + qtyQuestionsToDo + "\n";

        AddQuizResultsToFile();
        
    }

    public static IEnumerator TimeOver()
    {
        instance.BlockButtons();
        Debug.Log("Informar de algum jeito SEM TEXTOS que o tempo acabou...");
        yield return new WaitForSeconds(5);
        instance.StartCoroutine(instance.VerifyAnswer(-1));
    }

    public int CalculateScore()
    {
        return correctAnswers * scoreIncrease[dificulty];
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
        /// Cria uma nova lista
        numbersList = new List<int>();

        /// Completa a lista com todas as opções possíveis
        for (int i = 0; i < questionGroup[dificulty].GetLenght(); i++)
        {
            numbersList.Add(i);
        }
    }

    private void BlockButtons()
    {
        foreach (TextMeshProUGUI buttonText in answerMeshText)
        {
            buttonText.transform.parent.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }

    private void UnblockButtons()
    {
        foreach (TextMeshProUGUI buttonText in answerMeshText)
        {
            buttonText.transform.parent.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }

    private void AddQuizResultsToFile()
    {
        string tempPath = Application.persistentDataPath + "/" + SaveManager.instance.player.GetNome() + ".xml";
        FileManager.instance.SetPath(tempPath);

        if (FileManager.instance.VerifyFile())
        {
            FileManager.instance.LoadFile();
        }
        else
        {
            FileManager.instance.CreateFile();

            string tempMsg = "Data e Hora,Dificuldade,Pergunta Escolhida,Resposta Escolhida\n";

            FileManager.instance.SetHeader(tempMsg);
            FileManager.instance.AddHeaderToFile();
        }

        for (int i = 0; i < questionAndAnswer.Count; i++)
        {
            FileManager.instance.SetData(questionAndAnswer[i].ToString());
            FileManager.instance.AddDataToFile();
        }
    }
    #endregion
}