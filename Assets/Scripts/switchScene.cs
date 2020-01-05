using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class switchScene : MonoBehaviour
{
	
	//public Text SceneText;
    // Start is called before the first frame update
    void Start()
    {
         //SceneText.text=gameManager.Singleton.scene.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void gotoSample(){
		SceneManager.LoadScene("SampleScene");
		gameManager.Singleton.scene++;
	}
	public void gotoTitle(){
		SceneManager.LoadScene("Title");
		gameManager.Singleton.scene++;
	}
	public void quit()
    {
        Application.Quit();
    }
    public void gotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void gotoFight()
    {
        SceneManager.LoadScene("Fight");
    }
    public void gotoFlight()
    {
        SceneManager.LoadScene("Flight");
    }
}
