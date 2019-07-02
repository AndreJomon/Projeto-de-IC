using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2StartWarning : MonoBehaviour
{
    private List<GameObject> potContent;
    public PlayVideoOnMouseOver playVideoOnMouseOver;
    public Text text; 
    public DeafText normalWarning;
    public DeafText passed;
    public DeafText failed;
    public DeafText tryBetter;

    private void Start()
    {
        potContent = Pot.GetPots();
        ActiveWarning();
    }

    public void Feedback(string s)
    {
        s = s.ToUpper();
        if (s.Equals("PASSED"))
        {
            PutVideoAndText(passed);
        }
        else if (s.Equals("TRYBETTER"))
        {
            PutVideoAndText(tryBetter);
        }
        else if (s.Equals("FAILED"))
        {
            PutVideoAndText(failed);
        }

        gameObject.SetActive(true);
    }


    private void ActiveWarning()
    {
        for (int i = 0; i < potContent.Count; i++)
        {
            if (potContent[i] != null)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void PutVideoAndText(DeafText deafText)
    {
        playVideoOnMouseOver.video = deafText.video;
        text.text = deafText.text;
    }

    public void Warning(DeafText deafText)
    {
        text.text = deafText.text;
        playVideoOnMouseOver.video = deafText.video;
        gameObject.SetActive(true);
        StartCoroutine(SetOff());
    }

    private IEnumerator SetOff()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetTrigger("Desaparecer");
    }

    public void DesactiveGameObject()
    {
        gameObject.SetActive(false);
    }
}
