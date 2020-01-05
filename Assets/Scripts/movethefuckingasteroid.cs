using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movethefuckingasteroid : MonoBehaviour
{
	public Vector2 speed;
	public int speedx;
	public int speedy;
	private Vector2 movement;
	private Vector3 siz;
	private Vector3 TR;
	private Vector3 BR;
	private Vector3 TL;
	private Vector3 BL;
	private float posx;
	private float posy;
	private float coin;
	
	private SpriteRenderer sprite;
	private Camera c;

    // Start is called before the first frame update
    void Start()
    {
		c=Camera.main;
		BL=c.ViewportToWorldPoint(new Vector3(0,0,0));
		BR=c.ViewportToWorldPoint(new Vector3(1,0,0));
		TL=c.ViewportToWorldPoint(new Vector3(0,1,0));
		TR=c.ViewportToWorldPoint(new Vector3(1,1,0));
	
		coin=Random.Range(-1f, 1f);
		if(coin>0f){
			posy=Random.Range(BL.y, TR.y);
			if(coin>0.5f){
				posx=TL.x;
				//posx=TR.x;
			}else{
				posx=BR.x;
			}
		}else{
			posx=Random.Range(BL.x, TR.x);
			if(coin<-0.5f){
				posy=TL.y;
			}else{
				posy=BR.y;
			}
		}
		//Debug.Log("posx="+posx);
		//Debug.Log("posy="+posy);
		
		//posx=Random.Range(0f, 1f);
		transform.position=new Vector3 (posx,posy,0);
		sprite = GetComponent<SpriteRenderer>();
		speedx=Random.Range(-5, 5);
		speedy=Random.Range(-5, 5);
		
		//Debug.Log(GetComponent<Transform>().position);
		
    }

    // Update is called once per frame
    void Update()
    {
		
		movement = new Vector2(speed.x*speedx,speed.y*speedy);
		GetComponent<Rigidbody2D>().velocity = movement;
		siz.x=(gameObject.GetComponent<SpriteRenderer>().bounds.size.x);
		siz.y=(gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
		if (transform.position.y < BL.y + (siz.y / 2) - 2)//bas
			DestResp();
		if (transform.position.y > TL.y - (siz.y / 2) + 2)//haut
			DestResp();
		if (transform.position.x < BL.x + (siz.x / 2) - 2)//gauche
			DestResp();
		if (transform.position.x > TR.x - (siz.x / 2) + 2)//droite
			DestResp();


	}
	public void DestResp()
	{
		Destroy(gameObject);
		Instantiate(Resources.Load("Asteroid"));//.gameObject.tag = "Enemy"; ;
		//GameObject.FindGameObjectWithTag("GameController")./*getComponent<gameManager>()*/respawnAst();

	}

}
//GameObject.finGameObjectWithTag("Asteroid"); 50fps=1s