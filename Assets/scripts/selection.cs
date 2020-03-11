using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{
    //this script selects who the player plays and holds the controls of the player
    [Header("[0]=Horizontal" +
        " [1]=Vertical" +
        " [2]=Jump,x", order = 0)]
    [Header("other selectors",order =1)] 

    [SerializeField] List<GameObject> select = new List<GameObject>();

    [Header("player objects",order = 2)]

    public List<GameObject> player = new List<GameObject>();

    [Header("controls", order = 3)]

    [SerializeField] string[] buttons = new string[0];
    int judge;
    int resize;
    bool reset;
   [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        judge = 0;
        reset = true;
        resize = player.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (resize != player.Count)
        {
            for(int i=0; i < select.Count; i++)
            {
                if(select[i] == null)
                {
                    select.RemoveAt(i);
                    resize = player.Count;
                }
            }
            
        }

        if (Input.GetAxisRaw(buttons[0])!=0 && reset == true)
        {
            judge +=1* Mathf.RoundToInt( Input.GetAxisRaw(buttons[0]));
            target.transform.position = player[judge].transform.position + Vector3.up;
            reset = false;
        }

        if(Input.GetAxisRaw(buttons[0]) == 0)
        {
            reset = true;
        }

        if (Input.GetAxisRaw(buttons[2])!=0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < select.Count)
                {
                    select[i].GetComponent<selection>().player.RemoveAt(judge);
                }
                player[judge].GetComponent<movement>().keys[i] = buttons[i];

            }
            Destroy(target);
            player[judge].GetComponent<movement>().player1 = true;
            Destroy(gameObject);
        }

       

        judge = Mathf.Clamp(judge, 0, select.Count);
        
        
    }
}
