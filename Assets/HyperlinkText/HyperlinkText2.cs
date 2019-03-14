using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

//This script should be placed on a UI Text gameobject.

[RequireComponent(typeof(GetWordOnClick))]
public class HyperlinkText2 : MonoBehaviour, IPointerDownHandler
{
    [Tooltip("The color to set links, labled as <link=url>...</link> to.")]
    public Color linkColor = Color.blue;
    [Tooltip("The color to set email links, labled as <email=address>...</email> to.")]
    public Color emailColor = Color.green;
    [Tooltip("Optional: If set, then the mouse cursor will change when hovered over links/email tags.")]
    public Texture2D hoverCursor;

    public List<ParsedXMLText> xml = new List<ParsedXMLText>();
    private bool overHyperlink; //set to public to test hover events on links and email tags

    private Text txt;
    private GetWordOnClick wordGetter;

    [Serializable]
    public class ParsedXMLText
    {
        public string name; //associated text parsed from this XML code tag...
        //Ex, if: <link=www.simpleminded.x10host.com>Visit my site!</link>, then text = "Visit my site!"

        public string email, subject, body; //any associated email fields parsed from this XML code tag
        public string link; //any associated link parsed from this XML code tag
    };

    //Initialize and parse the text at start
    void Start()
    {
        txt = GetComponent<Text>();
        wordGetter = GetComponent<GetWordOnClick>();
        txt.text = ParseText(txt.text);
    }

    //Try to run this check as infrequently as possible...
    private void LateUpdate()
    {
        if (hoverCursor != null) { if (!IsInvoking("DelayHyperlinkRequest")){ Invoke("DelayHyperlinkRequest", 0.25f); } }
    }

    /// <summary>
    /// Parse the text of the given text info, for custom XML escape code. Parses the following:
    /// link, email, email with subject, email with subject and body
    /// </summary>
    /// <param name="rawText">The text with XML code in it, to parse</param>
    /// <returns></returns>
    public string ParseText(string rawText)
    {
        string parsed = rawText;
        string[] isolated = new string[0];

        isolated = parsed.Split(new string[] { "<" }, StringSplitOptions.None);
        for (int i = 1; i < isolated.Length; i++)
        {
            string focus = isolated[i].Split('>')[0].Trim();

            //<email> parsing...
            if (focus.StartsWith("email="))
            {
                string email = "", subject = "", body = "";
                string linkTxt = "";

                try
                {
                    //Parse through the email tag and extract the email, subject (if applicable) and body (if applicable)
                    string[] parsedFields = new string[0];

                    linkTxt = parsed.Substring(parsed.IndexOf(focus + ">") + (focus + ">").Length);
                    linkTxt = linkTxt.Substring(0, linkTxt.IndexOf('<'));

                    parsedFields = focus.Split(new string[] { "email=", "," }, StringSplitOptions.None);
                    email = parsedFields[1];

                    parsedFields = focus.Split(new string[] { ",subject=", "," }, StringSplitOptions.None);
                    subject = parsedFields[1].Replace("\"", "");

                    parsedFields = focus.Split(new string[] { ",body=" }, StringSplitOptions.None);
                    body = parsedFields[1].Replace("\"", "");
                }
                catch (IndexOutOfRangeException) { }; //Most likely if there was an OutOfRangeException, is because the tag does not contain a subject and body, which is acceptible.

                CreateParsedEmailXMLText(linkTxt, email, subject, body);

                parsed = parsed.Replace("<" + focus + ">", "<color=#" + ColorUtility.ToHtmlStringRGB(emailColor) + ">");
            }

            if (focus.Contains("/email"))
            {
                parsed = parsed.Replace("<" + focus + ">", "</color>");
            }

            //<link> parsing...
            if (focus.StartsWith("link="))
            {
                string link = focus.Split('=')[1];
                string linkTxt = parsed.Substring(parsed.IndexOf(focus + ">") + (focus + ">").Length);
                linkTxt = linkTxt.Substring(0, linkTxt.IndexOf('<'));

                CreateParsedLinkXMLText(linkTxt, link);

                parsed = parsed.Replace("<" + focus + ">", "<color=#" + ColorUtility.ToHtmlStringRGB(linkColor) + ">");
            }

            if (focus.Contains("/link"))
            {
                parsed = parsed.Replace("<" + focus + ">", "</color>");
            }
        }

        return parsed;
    }

    //----------------------------Populating xml with ParsedXMLText Functions (start)-----------------------------------

    //Create a parse for EMAIL tags
    void CreateParsedEmailXMLText(string text, string email = "", string subject = "", string body = "")
    {
        ParsedXMLText parsedXML = new ParsedXMLText();
        parsedXML.name = text;
        parsedXML.email = email;
        parsedXML.subject = subject;
        parsedXML.body = body;
        xml.Add(parsedXML);
    }
     
    //Create a parse for LINK tags
    void CreateParsedLinkXMLText(string text, string link = "")
    {
        ParsedXMLText parsedXML = new ParsedXMLText();
        parsedXML.name = text;
        parsedXML.link = link;
        xml.Add(parsedXML);
    }

    //----------------------------Populating xml with ParsedXMLText Functions (end)-------------------------------------

    public void OnPointerDown(PointerEventData eventData)
    {
        //register click events with a delay to allow GetWordOnClick to retrieve is data first OnPointerDown before this one requests.
        //(prevents this OnPointerClick from potentially firing before GetWordOnClick.OnPointerClick)
        Invoke("DelayRetrieve", 0.5f);
    }

    //Delay by a short timeframe before actually calling GetWordOnClick, to ensure it has its data before retrieving it.
    void DelayRetrieve()
    {
        string selectedWord = wordGetter.GetSelectedWord(new string[] { "<", ">", "-", " " }); //Get the selected word filtering out some characters that may be included.
        //Modify/add onto this list as needed. You can uncomment the below line for testing:
        //print(selectedWord);

        //cycle through every known XML parsed data from the XML array, if the selected word is within any of the XML parsed data, a weblink-click event happens (Application.OpenURL).
        for (int i = 0; i < xml.Count; i++)
        {
            if (xml[i].name.Contains(selectedWord))
            {
                //Links
                if (!string.IsNullOrEmpty(xml[i].link)) { Application.OpenURL(xml[i].link); }

                //Email
                string emailParams = "";
                if (!string.IsNullOrEmpty(xml[i].email)) { emailParams = xml[i].email; }
                if (!string.IsNullOrEmpty(xml[i].subject)) { emailParams += "?subject=" + xml[i].subject; }
                if (!string.IsNullOrEmpty(xml[i].body)) { emailParams += "&body=" + xml[i].body; }
                if (!string.IsNullOrEmpty(emailParams)) { Application.OpenURL("mailto:" + emailParams); }

                break; //exit for-loop once we find what we want...
            }
        }
    }

    //Delay by a short timeframe before actually calling GetWordOnClick, to ensure it has its data before retrieving it.
    void DelayHyperlinkRequest()
    {
        wordGetter.OnPointerHover(); //Call the OnPointerHover function (this is NOT an event)
        string selectedWord = wordGetter.GetSelectedWord(new string[] { "<", ">", "-", " " }); //Get the selected word filtering out some characters that may be included.
        //Modify/add onto this list as needed. You can uncomment the below line for testing:
        //print(selectedWord);

        overHyperlink = false;

        //cycle through every known XML parsed data from the XML array, if the selected word is within any of the XML parsed data, a hover-event mouse change happens.
        for (int i = 0; i < xml.Count; i++)
        {
            if (xml[i].name.Contains(selectedWord) && !string.IsNullOrEmpty(selectedWord))
            {
                overHyperlink = true;
                break;
            }
        }

        if (overHyperlink) { Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto); } //If the mouse hovers over a link tag, set cursor to hover cursor
        else { Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); } //Otherwise, use default cursor
        //The above if-else statement can be changed to support SoftwareCurosr changes (for resolution universal image scaling of Images verse Cursors in use), however is more advanced, art-wise on dimensions.
    }

    /// <summary>
    /// Get the List of ParssedXMLText, populated at Start.
    /// </summary>
    /// <returns></returns>
    public List<ParsedXMLText> GetParsedXMLText() { return xml; }
}
