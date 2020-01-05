using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class manageLife : MonoBehaviour
{
    public Camera c;
    private int lives;
    private bool blink;
    private int timer;
    public int tinvul;
    public SpriteRenderer sprite;
    public Sprite backup;
    public Animator anim;
    public Animator backupa;
    public Animator dmga;
    public Sprite dmg;
    private int timer2;
    //private bool transistion;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        backup = sprite.sprite;
        anim = GetComponent<Animator>();
        backupa = anim;
        timer = 0;
        blink = false;
        tinvul = 250;//changeable
        c = Camera.main;
        lives = gameManager.Singleton.lives;
        //transition = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (true)//ansition)
        {
            timer2++;
            if (timer2 == 150)
            {
                SceneManager.LoadScene("Dialog");
            }
        }
        if (blink)
        {
            timer++;
            if (timer == tinvul)
            {
                timer = 0;
                blink = false;
                sprite.sprite = backup;
                //anim = backupa;
            }
            else if (timer % 10 == 0)
            {
                if (sprite.sprite ==null)// dmg)
                {
                    
                    sprite.sprite = backup;
                    anim.enabled = true;
                    //anim = backupa;
                }
                else
                {

                    sprite.sprite = null;// dmg;
                    anim.enabled = false;
                    //anim = null;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy"&&(!blink))
        {
            blink = true;
            lives--;
            gameManager.Singleton.lives--;
            if (lives == 5 || lives == 1)//bug étrange qui fait que ça se déclenche parfois si le vaisseau est touché pendant une phase d'invulnérabilité
            {//ce bug n'était pas là précédemment et sans que je change quoi que ce soit POUF! pas que ce soit vraiment génant si les déplacement ne fonctionnent pas bien.
                gameManager.Singleton.dialog++;
                SceneManager.LoadScene("Dialog");
            }
            if (lives == 0)//DABOMB !
            {
                c.backgroundColor = Color.white;
                //if (GameObject.FindGameObjectsWithTag("Enemy") != null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    GameObject.Destroy(enemy);
                    /*GameObject[] p = GameObject.FindGameObjectsWithTag("Asteroid");
                    int i = 0;
                    while (p[i] != null)
                        p[i].AddComponent<fade>();*/
                    
                }
            }
		}
    }
}
