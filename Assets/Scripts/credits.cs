using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
    
    private Vector3 posfade;
    private int timer;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
        posfade = GameObject.FindGameObjectWithTag("toFade").transform.position;
        //posfade = new Vector3(posfade.x, posfade.y - 1, posfade.z);
        timer = 0;
        //get title
        movement = new Vector2(0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer % 15 == 0) {
            GetComponent<Rigidbody2D>().velocity = movement;
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        

        /*if (transform.position.y==posfade.y)
        {
            gameObject.AddComponent<fadeText>();
        }*/
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "toFade")
        {
            gameObject.AddComponent<fadeText>();
        }
    }

}
