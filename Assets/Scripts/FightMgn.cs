using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightMgn : MonoBehaviour
{
    private Vector3 TR;
    private Vector3 BR;
    private Vector3 TL;
    private Vector3 BL;

    public SpriteRenderer Lfist;
    public SpriteRenderer Rfist;
    public SpriteRenderer Brutus;
    private Sprite brts;
    public Sprite Brutus_hurt;
    public Sprite Brutus_ko;
    public Camera c;
    public Button dodge;
    public Button block;
    public Button counter;
    private Sprite Lf;
    private Sprite Rf;
    public int lifeP;
    public int lifeE;
    public Text Plife;
    public Text Elife;
    public Text Ename;
    public Text result;
    private string E_name;
    private int beginplife;
    private int beginelife;
    public AudioSource punchsfx;
    public AudioSource oofsfx;

    private bool blinking;
    private int blinkometer;

    private bool over;
    private bool dodged;
    private bool blocked;
    //public Renderer counterRenderer;

    //P -> Player
    //E -> Enemy

    private int time;

    private float coin;
    // Start is called before the first frame update
    void Start()
    {
        E_name = "Brutus";
        brts = Brutus.sprite;
        time = 0;
        c = Camera.main;
        BL = c.ViewportToWorldPoint(new Vector3(0, 0, 0));
        BR = c.ViewportToWorldPoint(new Vector3(1, 0, 0));
        TL = c.ViewportToWorldPoint(new Vector3(0, 1, 0));
        TR = c.ViewportToWorldPoint(new Vector3(1, 1, 0));

        //Lfist<Renderer>().enabled = !Lfist<Renderer>().enabled;
        //Rfist<Renderer>().enabled = !Rfist<Renderer>().enabled;
        Lf = Lfist.sprite;
        Rf = Rfist.sprite;
        Lfist.sprite = null;
        Rfist.sprite = null;
        Ename.text = E_name;

        beginplife = lifeP;
        beginelife = lifeE;

        dodged = blinking = blocked = false;

        
        counter.gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        dodge.gameObject.SetActive(false);
        result.text = null;
        over = false;


        //counter<Renderer>().enabled = !counter<Renderer>().enabled;

    }

    // Update is called once per frame
    void Update()
    {

        Plife.text = "your life : "+lifeP.ToString() + "/"+beginplife;
        Elife.text = "enemy life : "+lifeE.ToString();
        if (!over)
        {
            time++;
            if (time > 0 && (time % 500 == 0))
            {
                dodged = false;
                blocked = false;
                //Debug.Log("time = " + time);
                coin = Random.Range(0f, 1f);
                if (coin < 0.4f)
                {
                    Lfist.sprite = Lf;
                    rndpos(block);
                    block.gameObject.SetActive(true);
                    rndpos(dodge);
                    dodge.gameObject.SetActive(true);
                }
                if (coin > 0.60)
                {
                    Rfist.sprite = Rf;
                    rndpos(block);
                    block.gameObject.SetActive(true);
                    rndpos(dodge);
                    dodge.gameObject.SetActive(true);
                }
                else
                {
                    Lfist.sprite = Lf;
                    Rfist.sprite = Rf;
                    rndpos(block);
                    block.gameObject.SetActive(true);
                }
            }
            else
            {
                if (time > 50 && ((time - 50) % 500 == 0))//remove dodge
                    dodge.gameObject.SetActive(false);
                if (time > 100 && ((time - 100) % 500 == 0))//process hit
                {
                    block.gameObject.SetActive(false);
                    if (dodged)
                    {
                        rndpos(counter);
                        counter.gameObject.SetActive(true);

                    }
                    else
                    {
                        oofsfx.Play();
                        //hit taken sfx
                        if (blocked)
                        {
                            lifeP -= 25;
                            if (lifeP < 1)
                                lose();
                            rndpos(counter);
                            counter.gameObject.SetActive(true);
                            //dmg/2
                        }
                        else
                        {
                            lifeP -= 50;
                            if (lifeP < 1)
                                lose();
                        }
                    }
                    Lfist.sprite = null;
                    Rfist.sprite = null;
                }
                if (time > 250 && (time - 250) % 500 == 0)
                    counter.gameObject.SetActive(false);
            }
            if (blinking)
            {
                if (blinkometer % 15 == 0)
                    if (Brutus.sprite != null)
                    {
                        Brutus.sprite = null;
                    }
                    else
                    {
                        Brutus.sprite = Brutus_hurt;
                    }
                blinkometer -= 1;
                if (blinkometer == 0)
                {
                    blinking = false;
                    Brutus.sprite = brts;
                    if (lifeE < 1)
                        Brutus.sprite = Brutus_ko;
                }
            }
        }
    }

    public void blockAttack()
    {
        //c.backgroundColor = Color.yellow;
        Debug.Log("block");
        blocked = true; 
        counter.gameObject.SetActive(false);
        dodge.gameObject.SetActive(false);
        block.gameObject.SetActive(false);

    }

    public void dodgeAttack()
    {
        //c.backgroundColor = Color.black;
        Debug.Log("dodge");
        dodged = true;
        counter.gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        dodge.gameObject.SetActive(false);
    }

    public void counterAttack()
    {
        //c.backgroundColor = Color.white;
        Debug.Log("counter");
        lifeE -= 50;
        //Brutus-> sprite hurt
        counter.gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        dodge.gameObject.SetActive(false);
        blinking = true;
        blinkometer = 150;
        punchsfx.Play();
        if (lifeE < 1)
            win();

    }
    public void win()
    {
        result.gameObject.SetActive(true);
        result.text = "You win !";
        result.color = Color.yellow;
        Brutus.sprite = Brutus_ko;
        over = true;
        //sprite ko
    }
    public void lose()
    {
        result.gameObject.SetActive(true);
        result.text = "You lose !";
        result.color = Color.red;
        over = true;  
    }
    public void rndpos(Button b)
    {
        float x = Random.Range(BL.x, TR.x);// - ScreenToWorldPoint(b.GetComponent<RectTransform>().rect.width));// image.bounds.size.x);;
        float y = Random.Range(BL.y, TR.y);// - ViewportToWorldPoint(b.GetComponent<RectTransform>().rect.height));

        b.gameObject.transform.position = new Vector3(x,y,1);
        Debug.Log(b.gameObject.transform.position);
    }
}
