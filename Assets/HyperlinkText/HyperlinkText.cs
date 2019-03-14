using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

//Place this script on any TextMeshPro Text gameobject, that should support hyperlinks.
public class HyperlinkText : MonoBehaviour, IPointerDownHandler
{

    private TextMeshProUGUI txt; //reference to the actual TextMeshPro Text element
    private Canvas canvas; //active canvas
    private Camera cam; //active camera

    // Use this for initialization
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        canvas = GetComponentInParent<Canvas>();

        // Get a reference to the camera if Canvas Render Mode is not ScreenSpace Overlay.
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            cam = null;
        else
            cam = canvas.worldCamera;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Check if mouse intersects with any links.
        // When clicking, get the index of the link we just clicked on/"selected" - if we didnt click on a link, itll be -1
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(txt, Input.mousePosition, cam);

        // Handle link selection
        if (linkIndex < txt.textInfo.linkInfo.Length && linkIndex > -1)
        {
            // Get the linkInfo of the selected link we just clicked on (contains the id as our url, name and other useful stuff)
            TMP_LinkInfo linkInfo = txt.textInfo.linkInfo[linkIndex]; 
            
            // Open webpage of hyperlink, if the text of the hyperlink was retrieved
            if (!string.IsNullOrEmpty(linkInfo.GetLinkText())) { Application.OpenURL(linkInfo.GetLinkID()); }
        }
    }
}
