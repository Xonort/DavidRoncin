using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//SceneManager.LoadScene("scenename");

public class gameManager : MonoBehaviour
{
	public static gameManager Singleton {get;private set;}
	
	public int scene;
	public bool paused;
	public int timer;
	public AudioSource bgMusic;
	/*public bool fading;
	public ArrayList<gameObject> toFade;*/
	
	private void Awake(){
		if(Singleton==null){
			Singleton = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(gameObject);
		}
	}
    // Start is called before the first frame update
    void Start()
    {

		if (scene == 1)
		{
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
			Instantiate(Resources.Load("Asteroid"));
		}
	}

	public void respawnAst()
    {
		Instantiate(Resources.Load("Asteroid"));
	}

    // Update is called once per frame
    void Update()
    {
		if(!paused)
			timer++;/*
		if (fading)
			fade();
		*/
    }
	
	public void openOptions(){
		pause();
		displayOptions();
	}
	public void pause(){
		paused=!paused;
		
	}
	public void displayOptions(){
		
	}
	/*
	public void addFade(gameObject go){
		toFade.Add(go);
		fading = true;
	}
	public void fade(){
		if (toFade.Count>0)
		{
			int i = 0;
			while (toFade[i] != null)
			{
				Color col = toFade[i].GetComponent<SpriteRenderer>().color;
				if (col.a < 0)
				{
					Destroy(gameObject);
					Debug.Log("Destroyed");
					toFade.Remove(toFade[i]);
				}
				col.a -= 0.01f;
			}
		}
	}*/
	
}
