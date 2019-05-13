using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    List<Player> ranking = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {

        Player p1 = new Player();
        Player p2 = new Player();
        Player p3 = new Player();
        Player p4 = new Player();
        Player p5 = new Player();

        p1.SetAll(0, "Joca", "3ºão", 200);
        p2.SetAll(1, "Mari", "2ºão", 5411);
        p3.SetAll(2, "Alan", "3ºão", 357);
        p4.SetAll(3, "Joco", "1ºão", 4856);
        p5.SetAll(4, "Valtdisney", "3ºão", 2);

        ranking.Add(p1);
        ranking.Add(p2);
        ranking.Add(p3);
        ranking.Add(p4);
        ranking.Add(p5);

        Debug.Log("Antes de organizar:");
        foreach (Player p in ranking)
        {
            p.ShowAll();
        }

        ranking.Sort(delegate (Player a, Player b)
        {
            if (a.GetScore() > b.GetScore()) return -1;
            else return 1;
        });

        Debug.Log("Depois de organizar:");
        foreach (Player p in ranking)
        {
            p.ShowAll();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
