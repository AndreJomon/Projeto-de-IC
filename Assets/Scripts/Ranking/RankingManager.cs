using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance;
    public int rankingSize = 10;

    public GameObject podiumCanvas;
    public GameObject rankingCanvas;
    public GameObject rankingContent;

    public GameObject rankingPrefab;
    private List<GameObject> instantiatedPrefabs;

    private List<Player> ranking = new List<Player>();
    private int rankingPodium = 3;

    public UnityEngine.UI.Text[] podiumText;

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

        LoadPlayers();
        SetRanking();
        ShowRanking();
        ShowPodium();
    }

    public void LoadPlayers()
    {
        for (int i = 0; i < SaveManager.slotsListSize; i++)
        {
            if (!SaveManager.instance.list.slotsList.Contains(i))
            {
                ranking.Add(SaveManager.instance.LoadPlayer(i));
            }
        }
    }

    public void SetRanking()
    {
        ranking.Sort(delegate (Player a, Player b)
        {
            int pos;
            if (a.GetTotalScore() > b.GetTotalScore())
            {
                pos = -1;
            }
            else
            {
                pos = 1;
            }

            return pos;
        });

        for (int i = 0; i < ranking.Count; i++)
        {
            ranking[i].SetRanking(i + 1);
        }
    }

    public void ShowPodium()
    {
        int count = rankingPodium;

        if (ranking.Count < rankingPodium)
        {
            count = ranking.Count;
        }

        for (int i = 0; i < count; i++)
        {
            podiumText[i].text = ranking[i].GetTotalScore() + "\n" + ranking[i].GetNome() + "\n" + ranking[i].GetClassroom();
        }
    }

    public void ShowRanking()
    {
        if (rankingSize > ranking.Count)
        {
            rankingSize = ranking.Count;
        }

        for (int i = 0; i < rankingSize; i++)
        {
            GameObject temp = Instantiate(rankingPrefab, rankingContent.transform);
            temp.GetComponent<RankingPrefabUpdate>().UpdatePrefab(ranking[i]);
        }
    }

    public void FullRanking()
    {
        rankingCanvas.SetActive(true);
    }

    public void BackToPodium()
    {
        rankingCanvas.SetActive(false);
    }
}