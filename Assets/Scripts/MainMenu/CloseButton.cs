using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{

    GameObject closeMenu;

    private void Awake()
    {
        closeMenu = Resources.Load("Prefabs/SubMenus/CloseMenu") as GameObject;
    }

    public void OpenCloseMenu()
    {
        if (GameObject.Find("CloseMenu(Clone)") == null)
        {
            GameObject newOptionsMenu;
            newOptionsMenu = Instantiate(closeMenu);
            newOptionsMenu.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
        else
        {
            Cancel();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        GameObject buttonParent;
        buttonParent = this.transform.parent.gameObject;
        Destroy(buttonParent);
    }

}
