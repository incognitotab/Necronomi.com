using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class godscript : MonoBehaviour
{
    //thehills = 0,the woods = 1,the subarbs = 2,the desert = 3,the highway = 4,the airport = 5,the town = 6
    int turncount =0;
    int globalfbistatcount;
    public int ready;
    public int read;
    int maxfbistat;
    List<statcalculator> playersfight = new List<statcalculator>();
    [SerializeField] statcalculator[] players = new statcalculator[1];
    [SerializeField] populationcounter[] arealist = new populationcounter[1];
    [SerializeField] Sprite[] backgrounds = new Sprite[1];
    [SerializeField] Sprite[] bensprites = new Sprite[1];
    [SerializeField] Sprite[] malsprites = new Sprite[1];
    [SerializeField] Sprite[] mysprite = new Sprite[1];
    [SerializeField] Sprite[] defeatsprite = new Sprite[1];
    [SerializeField] Image[] backgroundholder = new Image[3];
    [SerializeField] Image[] peopleholder = new Image[3];
    [SerializeField] Image[] monsterholder = new Image[3];

    // Start is called before the first frame update
    public void spritechooser(int place)
    {
        int value = 0;
        for (int i = 0; i < arealist.Length; i++)
        {
           
            if (arealist[i].counter.Count > 0)
            {
                //value = backgroundholder[value].sprite == null ? value : value+1;
                backgroundholder[value].sprite = backgrounds[i];
                value = value>=2?2:value+1;
                Debug.Log(value);
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            switch (players[i].selection)
            {
                case 1:
                   monsterholder[i].sprite = bensprites[i];
                    peopleholder[i].sprite = bensprites[3];
                break;

                case 2:
                    monsterholder[i].sprite = malsprites[i];
                    peopleholder[i].sprite = malsprites[3];
                break;

                case 3:
                    monsterholder[i].sprite = mysprite[i];
                    peopleholder[i].sprite = mysprite[3];
                break;
            }

        }
    }
    public void monsterfight(populationcounter fightplace,int place)
    {
        if (fightplace != null)
        {
            Vector2 hey =  Vector2.zero;
            
            for(int i = 0; i < fightplace.counter.Count; i++)
            {
                playersfight.Add(fightplace.counter[i].GetComponent<statcalculator>());
                
            }
            
            hey.x = playersfight[0].selection == 1 ? playersfight[0].malicious : hey.x;
            hey.x = playersfight[0].selection == 2 ? playersfight[0].benovalence : hey.x;
            hey.x = playersfight[0].selection == 3 ? playersfight[0].mysterious : hey.x;
            hey.y = playersfight[1].selection == 1 ? playersfight[1].malicious : hey.y;
            hey.y = playersfight[1].selection == 2 ? playersfight[1].benovalence : hey.y;
            hey.y = playersfight[1].selection == 3 ? playersfight[1].mysterious : hey.y;

            if (hey.x > hey.y)
            {
              float rand =  Random.Range(1, hey.x + hey.y);
                if(rand-hey.x < rand - hey.y)
                {
                    playersfight[0].population *= 5;
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i] == playersfight[i])
                        {
                            backgroundholder[i].sprite = backgrounds[place];
                           // monsterholder[i].sprite = defeatsprite[i];

                        }
                    }
                }
                else if(rand - hey.x > rand - hey.y)
                {
                    playersfight[1].population *= 5;
                }
            }

        }
    }

    public void turnchange()
    {
        globalfbistatcount = turncount > 10 ? Mathf.RoundToInt( maxfbistat / 10 * turncount) : maxfbistat;

        ready = ready<=0 ? 0:ready--;
    }


}
