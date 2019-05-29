using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorManager : MonoBehaviour
{
    /// <summary>
    /// Painéis que devem ser exibidos em momentos específicos
    /// </summary>
    /// Painel de verificação de login
    [SerializeField] private GameObject passwordPanel;
    /// Painel da área principal do professor
    [SerializeField] private GameObject professorArea;
    /// Painel de troca de senha
    [SerializeField] private GameObject changePassord;
    /// Painel de exibição de mensagem de erro
    [SerializeField] private GameObject messagePanel;
    /// Painel de confirmação de remoção de jogador
    [SerializeField] private GameObject confirmPanel;

    /// <summary>
    /// Campos de entrada de informação para a troca de senha
    /// </summary>
    [SerializeField] private UnityEngine.UI.InputField curPassword;
    [SerializeField] private UnityEngine.UI.InputField newPassword;
    [SerializeField] private UnityEngine.UI.InputField newPasswordRewrite;

    [SerializeField] private UnityEngine.UI.Text messageText;

    private readonly string senhaPadrao = "1234";

    private void Start()
    {
        // Se não existe uma senha salva no PlayerPrefs, salva uma senha padrão
        if (!PlayerPrefs.HasKey("Senha"))
        {
            PlayerPrefs.SetString("Senha", senhaPadrao);
        }
    }

    /// <summary>
    /// Função que verifica se a senha está correta para liberar o acesso ao professor
    /// </summary>
    /// <param name="password"></param>
    public void CheckPassword(UnityEngine.UI.InputField password)
    {
        if (PlayerPrefs.GetString("Senha") == password.text)
        {
            passwordPanel.SetActive(false);
            professorArea.SetActive(true);
            changePassord.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowMessage("Senha Incorreta"));
        }
    }
    
    /// <summary>
    /// Função que ativa o painel de mudança de senha
    /// </summary>
    public void ChangePasswordPanel()
    {
        changePassord.SetActive(true);
    }

    /// <summary>
    /// Função que realiza a mudança de senha
    /// </summary>
    public void ChangePassword()
    {
        if (curPassword.text == PlayerPrefs.GetString("Senha"))
        {
            if (newPassword.text == newPasswordRewrite.text)
            {
                if (!newPassword.text.Equals(""))
                {
                    PlayerPrefs.SetString("Senha", newPassword.text);
                    StartCoroutine(ShowMessage("Senha alterada com sucesso!"));

                    GoToProfessorAccessPanel();
                }
                else
                {
                    StartCoroutine(ShowMessage("Nova senha inválida"));
                }
            }
            else
            {
                StartCoroutine(ShowMessage("Senhas não conferem"));
            }
        }
        else
        {
            StartCoroutine(ShowMessage("Senha atual incorreta"));
        }
    }

    /// <summary>
    /// Função que retorna ao painel do professor
    /// </summary>
    public void GoToProfessorAccessPanel()
    {
        ClearPasswordFields();
        passwordPanel.SetActive(false);
        professorArea.SetActive(true);
        changePassord.SetActive(false);
    }

    /// <summary>
    /// Função que limpa os campos da troca de senha
    /// </summary>
    public void ClearPasswordFields()
    {
        curPassword.text = "";
        newPassword.text = "";
        newPasswordRewrite.text = "";
    }

    /// <summary>
    /// Função encarregada de mostrar uma mensagem na tela durante 5s
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public IEnumerator ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
        yield return new WaitForSeconds(5f);
        messagePanel.SetActive(false);
    }

    /// <summary>
    /// Função para resetar a senha para a senha padrão - utilizada para testes
    /// </summary>
    public void ResetSenha()
    {
        PlayerPrefs.SetString("Senha", senhaPadrao);
    }

    /// <summary>
    /// Função para ativar o painel de confirmação de remoção de jogadores
    /// </summary>
    public void ConfirmPanel()
    {
        confirmPanel.SetActive(true);
    }
}
