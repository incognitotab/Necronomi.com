using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statcalculator : MonoBehaviour
{
  //this script calculates the stats of each player
  [SerializeField] int population;
   int malicious;
   int benovalence;
   int mysterious;
  [SerializeField] float multiplier;
  [SerializeField] int variable;
   float container;
  [SerializeField] public int selection;
  [SerializeField] int selector;
    float totalfbistat;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("area"))
        {
          population =  other.gameObject.GetComponent<populationcounter>().population;
          multiplier = other.gameObject.GetComponent<populationcounter>().multiplier;
        }
    }

    public void sup()
    {
        float typeinc;
        container = (population) / variable;

        switch(selection)
        {
            case 1:
                typeinc = selector == selection ? multiplier : 1;
                malicious = malicious + Mathf.RoundToInt(container*typeinc);
                break;
            case 2:
                typeinc = selector == selection ? multiplier : 1;
                benovalence = benovalence + Mathf.RoundToInt(container * typeinc);
                break;
            case 3:
                typeinc = selector == selection ? multiplier : 1;
                mysterious = mysterious + Mathf.RoundToInt(container * typeinc);
                break;
        }
        
    }
}
