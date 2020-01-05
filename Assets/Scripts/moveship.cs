using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveship : MonoBehaviour
{

	public Vector2 speed;
	private Vector2 movement;
	private Vector3 scale;
	private Vector3 LH;
	private Vector3 RH;
	private Vector3 LB;
	private Vector3 RB;
	private Vector3 pos;
	private SpriteRenderer sprite;
	private Camera c;
	private Vector3 touchpos;
	private Touch touch;
	// Start is called before the first frame update
	void Start()
    {
	c=Camera.main;
	sprite = GetComponent<SpriteRenderer>();
	LH=c.ViewportToWorldPoint(new Vector3(0,0,0));
	RH=c.ViewportToWorldPoint(new Vector3(1,0,0));
	LB=c.ViewportToWorldPoint(new Vector3(0,1,0));
	RB=c.ViewportToWorldPoint(new Vector3(1,1,0));
	GetComponent<Transform>().position=new Vector3((LH.x+(sprite.bounds.size.x/2)),0,0);
	scale=new Vector3 (1,1,1);
    }
    // Update is called once per frame
    void Update()
    {
		
        float y=Input.GetAxis("Vertical");
        float x=Input.GetAxis("Horizontal");
		pos=GetComponent<Transform>().position;
	
		LH =c.ViewportToWorldPoint(new Vector3(0,0,0));
		LB=c.ViewportToWorldPoint(new Vector3(0,1,0));
	


		movement=new Vector2(speed.x*x,speed.y*y);
		pos.x=LH.x+(sprite.bounds.size.x/2);	



		if(x<0){
			//scale=new Vector3(-1,1,1);
		}
		else if(x>0){
			scale=new Vector3(1,1,1);
		}

		if(y<0&&pos.y<=(LH.y+(sprite.bounds.size.y/2))){
			movement.y=0;
			pos.y=(LH.y+(sprite.bounds.size.y/2));
		}
		else if (y>0&&pos.y>=(LB.y-(sprite.bounds.size.y/2))){
			movement.y=0;
			pos.y=(LB.y-(sprite.bounds.size.y/2));
		}

		GetComponent<Transform>().position=pos;
	
		GetComponent<Transform>().localScale=scale;
	
		GetComponent<Rigidbody2D>().velocity = movement;
		
    }
}
