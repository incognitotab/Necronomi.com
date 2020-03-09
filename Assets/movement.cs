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
    bool firstinput;
    
    public void Start()
    {
        player1 = false;
        sprite = GetComponent<SpriteRenderer>();
     
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (firstinput == true && god.ready==1)
        {
            selection = Input.GetButtonDown(keys[2]) ? 1 : selection;
            selection = Input.GetButtonDown(keys[3]) ? 2 : selection;
            selection = Input.GetButtonDown(keys[4]) ? 3 : selection;

            if (selection > 0)
            {
                collision.gameObject.GetComponent<populationcounter>().used();
                gameObject.GetComponent<statcalculator>().selection = selection;
                gameObject.GetComponent<statcalculator>().sup();
                selection = -1;
                
            }
        }
        if (Input.GetButtonDown(keys[2]) && selection ==0 && firstinput == false)
        {
            firstinput = true;
            god.ready++;
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        firstinput = false;
        selection = 0;
        god.ready = firstinput == true ? god.ready - 1 : god.ready;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player1 == true)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
             float y = Camera.main.orthographicSize * 2f;
        float x = Camera.main.aspect * y;
            pos.x = Mathf.Clamp(pos.x,sprite.size.x/x,1-sprite.size.x/x);
            pos.y = Mathf.Clamp(pos.y, sprite.size.y / y, 1 - sprite.size.y / y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            move = new Vector2(Input.GetAxisRaw(keys[0]), Input.GetAxisRaw(keys[1]));
           
        }
    }

    public void FixedUpdate()
    {
        transform.position =transform.position+ move * Time.fixedDeltaTime * 5;
    }
}
