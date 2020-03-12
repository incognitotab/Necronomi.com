using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //this script is mainly for inputs and movement
    [Header("[0]=Horizontal," +
       " [1]=Vertical" +
       " [2]=Jump,x", order = 0)]
    public string[] keys = new string[0];
    public bool player1;
    Vector3 move;
    SpriteRenderer sprite;
    float y;
    float x;
    int choice;
   [SerializeField] int selection;
   [SerializeField] godscript god;
   [SerializeField] GameObject graph;
   [SerializeField] movement playera, playerb;
   bool firstinput;
    [SerializeField] int decider;
   public bool decisionmade;
    public GameObject mediascreen;
    public GameObject background;
    
    public void Start()
    {
        player1 = false;
        sprite = GetComponent<SpriteRenderer>();
        selection = 0;
        decisionmade = false;
        
        
    }

    

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (player1 == true && collision.gameObject.layer==9)
        {
            if (firstinput == true && god.ready == 3)
            {
                sprite.color = Color.green;
                if (selection == 0)
                {
                    selection = Input.GetButtonDown(keys[2]) ? 1 : selection;
                    selection = Input.GetButtonDown(keys[3]) ? 2 : selection;
                    selection = Input.GetButtonDown(keys[4]) ? 3 : selection;
                }
                if(selection > 0)
                {
                    decisionmade = true;
                }

                if (decisionmade==true &&playera.decisionmade==true&&playerb.decisionmade==true)
                {
                    gameObject.GetComponent<statcalculator>().selection = selection;
                    collision.gameObject.GetComponent<populationcounter>().used();
                    gameObject.GetComponent<statcalculator>().sup();
                    god.turnchange();
                    graph.SetActive(true);
                    sprite.color = Color.white;
                    god.read = 3;
                    firstinput = false;
                    selection = -1;

                }
            }
            else if (Input.GetButtonDown(keys[2]) && firstinput == false )
            {
               
                firstinput = true;
                god.ready++;
            }
            if (god.read==0 && firstinput==false)
            {
                decisionmade = false;
               
            }
            if (graph.activeSelf == true)
            {
                bool trigger=false;
                if (Input.GetButtonDown(keys[2]) && god.read == decider)
                {
                    mediascreen.SetActive(false);
                    god.read--;
                    trigger = god.read == 0 ? false : true;
                    background.SetActive(trigger);
                }
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==9)
        {
            god.ready--;
            firstinput = false;
            selection = 0;
            graph.SetActive(false);
            sprite.color = Color.white;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        god.ready = Mathf.Clamp(god.ready, 0, 3);
        if (graph.activeSelf==false)
        {
            mediascreen.SetActive(true);
            background.SetActive(true);
        }
        //Physics2D.IgnoreLayerCollision(0, 9, true);
        if (player1 == true)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            float y = Camera.main.orthographicSize * 2f;
            float x = Camera.main.aspect * y;
            pos.x = Mathf.Clamp(pos.x,(transform.lossyScale.x/2)/x,1-(transform.lossyScale.x/2)/x);
            pos.y = Mathf.Clamp(pos.y, (transform.lossyScale.y/2) / y, 1 - (transform.lossyScale.y/2) / y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            move = new Vector2(Input.GetAxisRaw(keys[0]), Input.GetAxisRaw(keys[1]));
           
        }
    }

    public void FixedUpdate()
    {
        transform.position =transform.position+ move * Time.fixedDeltaTime * 5;
        
    }
}
