using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorManager : MonoBehaviour
{
    [SerializeField] private GameObject passwordPanel;
    [SerializeField] private GameObject professorArea;
    [SerializeField] private GameObject changePassord;
    [SerializeField] private GameObject messagePanel;

    [SerializeField] private UnityEngine.UI.InputField curPassword;
    [SerializeField] private UnityEngine.UI.InputField newPassword;
    [SerializeField] private UnityEngine.UI.InputField newPasswordRewrite;

    [SerializeField] private UnityEngine.UI.Text messageText;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Senha"))
        {
            PlayerPrefs.SetString("Senha", "SenhaPadrao");
        }
    }

    public void CheckPassword(UnityEngine.UI.InputField password)
    {
        if (PlayerPrefs.GetString("Senha") == password.text)
        {
            passwordPanel.SetActive(false);
            professorArea.SetActive(true);
            changePassord.SetActive(false);
        }
    }
    
    public void ChangePasswordPanel()
    {
        changePassord.SetActive(true);
    }

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

    public void GoToProfessorAccessPanel()
    {
        ClearPasswordFields();
        passwordPanel.SetActive(false);
        professorArea.SetActive(true);
        changePassord.SetActive(false);
    }

    public void ClearPasswordFields()
    {
        curPassword.text = "";
        newPassword.text = "";
        newPasswordRewrite.text = "";
    }

    public IEnumerator ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
        yield return new WaitForSeconds(5f);
        messagePanel.SetActive(false);
    }

    public void ResetSenha()
    {
        PlayerPrefs.SetString("Senha", "SenhaPadrao");
    }
}
