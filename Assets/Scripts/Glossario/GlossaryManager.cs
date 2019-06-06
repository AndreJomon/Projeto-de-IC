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

        for (int i = 0; i < glossaryList.glossary.Count; i++)
        {
            GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
            temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryList.glossary[i]);
            glossaryItems.Add(temp);
        }
    }

    public void UpdateGlossaryWindow(GlossaryItems glossaryListToShow)
    {
        glossaryItems.Clear();

        for (int i = 0; i < glossaryListToShow.glossary.Count; i++)
        {
            GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
            temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryList.glossary[i]);
            glossaryItems.Add(temp);
        }
    }

    public GlossaryItems SortGlossaryItemList(GlossaryItems listToSort)
    {
        listToSort.glossary.Sort(delegate (GlossaryElement a, GlossaryElement b)
        {
            return a.expression.CompareTo(b.expression);
        });

        return listToSort;
    }

    public GlossaryItems SearchExpression(GlossaryItems listToSearch, string expressionToFind)
    {
        List<GlossaryElement> temp = new List<GlossaryElement>();
        temp = listToSearch.glossary.FindAll(delegate (GlossaryElement a)
        {
            if (a.expression.ToUpper().Contains(expressionToFind.ToUpper())) return true;
            else return false;
        });
        listToSearch.glossary = temp;
        return listToSearch;
    }

    public void TestSort()
    {
        Debug.Log(searchBarText.text);
        foreach(GlossaryElement g in SearchExpression(glossaryList, searchBarText.text).glossary)
        {
            Debug.Log(g.expression);
        }

        //UpdateGlossaryWindow(SearchExpression(glossaryList, searchBarText.text));
    }
}
