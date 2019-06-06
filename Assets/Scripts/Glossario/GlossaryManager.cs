using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryManager : MonoBehaviour
{
    public GlossaryManager instance;
    public GlossaryItems glossaryList;

    public GameObject glossaryPrefab;
    public GameObject glossaryWindow;

    public UnityEngine.UI.Text searchBarText;

    [SerializeField] private List<GameObject> glossaryItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }

        //for (int i = 0; i < glossaryList.glossary.Count; i++)
        //{
        //    GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
        //    temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryList.glossary[i]);
        //    glossaryItems.Add(temp);
        //}

        UpdateGlossaryWindow(glossaryList.glossary);
    }

    public void UpdateGlossaryWindow(List<GlossaryElement> glossaryListToShow)
    {
        foreach(GameObject item in glossaryItems)
        {
            Destroy(item);
        }

        for (int i = 0; i < glossaryListToShow.Count; i++)
        {
            GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
            temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryListToShow[i]);
            glossaryItems.Add(temp);
        }
    }

    public List<GlossaryElement> SortGlossaryItemList(GlossaryItems listToSort)
    {
        List<GlossaryElement> temp = new List<GlossaryElement>();

        temp = listToSort.glossary;
        temp.Sort(delegate (GlossaryElement a, GlossaryElement b)
        {
            return a.expression.CompareTo(b.expression);
        });

        return temp;
    }

    public List<GlossaryElement> SearchExpression(GlossaryItems listToSearch, string expressionToFind)
    {
        List<GlossaryElement> temp = new List<GlossaryElement>();

        temp = listToSearch.glossary;
        temp = temp.FindAll(delegate (GlossaryElement a)
        {
            if (a.expression.ToUpper().Contains(expressionToFind.ToUpper())) return true;
            else return false;
        });

        return temp;
    }

    public void TestSort()
    {
        Debug.Log(searchBarText.text);
        List<GlossaryElement> temp = SearchExpression(glossaryList, searchBarText.text);
        foreach (GlossaryElement g in temp)
        {
            Debug.Log(g.expression);
        }

        UpdateGlossaryWindow(SearchExpression(glossaryList, searchBarText.text));
    }
}
