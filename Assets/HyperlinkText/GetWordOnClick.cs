using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Script originally created by: The-Oddler (https://forum.unity3d.com/threads/finding-what-letter-word-i-clicked.268311/)

public class GetWordOnClick : MonoBehaviour, IPointerDownHandler
{
    private Text _text;
    private string word = "";

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void OnDrawGizmos()
    {
        var text = GetComponent<Text>();
        var textGen = text.cachedTextGenerator;
        var prevMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;
        for (int i = 0; i < textGen.characterCount; ++i)
        {
            Vector2 locUpperLeft = new Vector2(textGen.verts[i * 4].position.x, textGen.verts[i * 4].position.y);
            Vector2 locBottomRight = new Vector2(textGen.verts[i * 4 + 2].position.x, textGen.verts[i * 4 + 2].position.y);

            Vector3 mid = (locUpperLeft + locBottomRight) / 2.0f;
            Vector3 size = locBottomRight - locUpperLeft;

            Gizmos.DrawWireCube(mid, size);
        }
        Gizmos.matrix = prevMatrix;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        word = string.Empty;
        eventData.Use();
        int index = GetIndexOfClick(eventData.pressEventCamera.ScreenPointToRay(eventData.position));
        if (index != -1) word = GetWordAtIndex(index);
    }

    public void OnPointerHover()
    {
        word = string.Empty;
        int index = GetIndexOfClick(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (index != -1) word = GetWordAtIndex(index);
    }

    int GetIndexOfClick(Ray ray)
    {
        Ray localRay = new Ray(
          transform.InverseTransformPoint(ray.origin),
          transform.InverseTransformDirection(ray.direction));

        Vector3 localClickPos =
          localRay.origin +
          localRay.direction / localRay.direction.z * (transform.localPosition.z - localRay.origin.z);

        Debug.DrawRay(transform.TransformPoint(localClickPos), Vector3.up / 10, Color.red, 2.0f);

        var textGen = _text.cachedTextGenerator;
        for (int i = 0; i < textGen.characterCount; ++i)
        {
            Vector2 locUpperLeft = new Vector2(textGen.verts[i * 4].position.x, textGen.verts[i * 4].position.y);
            Vector2 locBottomRight = new Vector2(textGen.verts[i * 4 + 2].position.x, textGen.verts[i * 4 + 2].position.y);

            if (localClickPos.x >= locUpperLeft.x &&
             localClickPos.x <= locBottomRight.x &&
             localClickPos.y <= locUpperLeft.y &&
             localClickPos.y >= locBottomRight.y
             )
            {
                return i;
            }
        }

        return -1;
    }

    string GetWordAtIndex(int index)
    {
        int begIndex = -1;
        int marker = index;
        while (begIndex == -1)
        {
            marker--;
            if (marker < 0)
            {
                begIndex = 0;
            }
            else if (!char.IsLetter(_text.text[marker]))
            {
                begIndex = marker;
            }
        }

        int lastIndex = -1;
        marker = index;
        while (lastIndex == -1)
        {
            marker++;
            if (marker > _text.text.Length - 1)
            {
                lastIndex = _text.text.Length - 1;
            }
            else if (!char.IsLetter(_text.text[marker]))
            {
                lastIndex = marker;
            }
        }

        return _text.text.Substring(begIndex, lastIndex - begIndex);
    }

    /// <summary>
    /// Get the selected word found on click.
    /// </summary>
    /// <returns></returns>
    public string GetSelectedWord() { return word; }

    /// <summary>
    /// Get the selected word found on click, with a filter through characters to exclude.
    /// </summary>
    /// <param name="filter">The array of characters to exclude on return.</param>
    /// <returns></returns>
    public string GetSelectedWord(string[] filter)
    {
        string filteredWord = word;

        if (filter.Length > 0) { for (int i = 0; i < filter.Length; i++) { filteredWord = filteredWord.Replace(filter[i], ""); } }

        return filteredWord;
    }

}