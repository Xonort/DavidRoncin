using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spawntitlebutton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        if (gameObject.tag == "last")
            button.gameObject.SetActive(true);
    }
}
