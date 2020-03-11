using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godscript : MonoBehaviour
{
    //thehills = 0,the woods = 1,the subarbs = 2,the desert = 3,the highway = 4,the airport = 5,the town = 6
    int turncount =0;
    int globalfbistatcount;
    public int ready;
    int maxfbistat;
    [SerializeField] List<statcalculator> players = new List<statcalculator>();
    [SerializeField] populationcounter[] arealist = new populationcounter[1];

    // Start is called before the first frame update

    public void monsterfight(populationcounter fightplace)
    {
        if (fightplace != null)
        {
            Vector2 hey =  Vector2.zero;
            
            for(int i = 0; i > fightplace.counter.Count; i++)
            {
                players.Add(fightplace.counter[i].GetComponent<statcalculator>());
                
            }
            hey.x = players[0].selection == 1 ? players[0].malicious : hey.x;
            hey.x = players[0].selection == 2 ? players[0].benovalence : hey.x;
            hey.x = players[0].selection == 3 ? players[0].mysterious : hey.x;
            hey.y = players[1].selection == 1 ? players[1].malicious : hey.y;
            hey.y = players[1].selection == 2 ? players[1].benovalence : hey.y;
            hey.y = players[1].selection == 3 ? players[1].mysterious : hey.y;

            if (hey.x > hey.y)
            {
              float rand =  Random.Range(1, hey.x + hey.y);
                if(rand-hey.x < rand - hey.y)
                {
                    players[0].population *= 5;
                }
                else if(rand - hey.x > rand - hey.y)
                {
                    players[1].population *= 5;
                }
            }

        }
    }

    public void turnchange()
    {
        globalfbistatcount = turncount > 10 ? Mathf.RoundToInt( maxfbistat / 10 * turncount) : maxfbistat;

        ready = 0;
    }


}
