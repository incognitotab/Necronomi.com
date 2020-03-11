using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populationcounter : MonoBehaviour
{
    // this script calculates the population and catch chance of a area
    public int population;
    [SerializeField] int minpopulation;
    int selector;
    public float catalyst;
    public List<GameObject> counter = new List<GameObject>();
    bool experienced;
   public int fbiareastat;
   [SerializeField] int fbistatincrease;
   [SerializeField] int maxfbistat;
   [SerializeField] godscript god;
    // Start is called before the first frame update
    public void Start()
    {
        fbiareastat = 0;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    counter.Add(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
    counter.Remove(collision.gameObject);
    }
    public void used()
    {
        population += Mathf.RoundToInt( minpopulation/2 * catalyst);
        catalyst = catalyst + 0.01f;
        fbiareastat = fbiareastat + fbistatincrease < maxfbistat ? fbiareastat + fbistatincrease : maxfbistat;
        if (counter.Count > 1)
        {
            god.monsterfight(this);
        }
        experienced = true;
    }

    public void unused()
    {if (experienced == false)
        {
            float percentage = catalyst * 0.25f;
            population = population * (catalyst - 1 + percentage) > minpopulation ? Mathf.RoundToInt(population * (catalyst - 1 + percentage)) : minpopulation;
            catalyst = catalyst - percentage > 1 ? catalyst - percentage : 1;
            fbiareastat = fbiareastat - (fbistatincrease/2) > maxfbistat ? fbiareastat - (fbistatincrease/2) : maxfbistat;
        }
        experienced = false;
    }

   
}
