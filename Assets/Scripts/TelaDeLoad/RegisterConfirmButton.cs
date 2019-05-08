using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterConfirmButton : MonoBehaviour
{
    public GameObject nameText;
    public GameObject classText;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (nameText.GetComponent<Text>().text.Equals("") || classText.GetComponent<Text>().text.Equals(""))
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void InputConfirm()
    {
        SaveManager.instance.CreateNewPlayer();
        SaveManager.instance.player.SetNome(nameText.GetComponent<Text>().text);
        SaveManager.instance.player.SetClassroom(classText.GetComponent<Text>().text);
    }
}
