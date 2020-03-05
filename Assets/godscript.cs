using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godscript : MonoBehaviour
{
    int turncount;
    int globalfbistatcount;
   public int ready;
    int maxfbistat;
    [SerializeField] populationcounter arealist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void turnchange()
    {
        globalfbistatcount = turncount > 10 ? Mathf.RoundToInt( maxfbistat / 10 * turncount) : maxfbistat;

        ready = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
