using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingPrefabUpdate : MonoBehaviour
{
    public UnityEngine.UI.Text rankingPosition;
    public UnityEngine.UI.Text score;
    public UnityEngine.UI.Text info;

    public void UpdatePrefab(Player player)
    {
        rankingPosition.text = player.GetRankingPosition().ToString();
        score.text = player.GetTotalScore().ToString();
        info.text = player.GetNome() + " - " + player.GetClassroom();
    }
}
