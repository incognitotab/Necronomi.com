using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populationcounter : MonoBehaviour
{
    // this script calculates the population and catch chance of a area
    public int population;
    [SerializeField] int minpopulation;
    public float multiplier;
    int selector;
    [SerializeField]  float catalyst;
    bool experienced;
    int fbiareastat;
    [SerializeField] int maxfbistat;
    // Start is called before the first frame update
    public void Start()
    {
        fbiareastat = 0;
    }
    public void used()
    {
        population = Mathf.RoundToInt( population * catalyst);
        catalyst = catalyst + 0.1f;
        multiplier = population / 1000;
        fbiareastat = fbiareastat + 10 > maxfbistat ? fbiareastat + 10 : maxfbistat;
        experienced = true;
    }

    public void unused()
    {if (experienced == false)
        {
            float percentage = catalyst * 0.25f;
            population = population * (catalyst - 1 + percentage) > minpopulation ? Mathf.RoundToInt(population * (catalyst - 1 + percentage)) : minpopulation;
            catalyst = catalyst - percentage > 1 ? catalyst - percentage : 1;
            fbiareastat = fbiareastat - 5 > maxfbistat ? fbiareastat - 5 : maxfbistat;
        }
        experienced = false;
    }

   
}
