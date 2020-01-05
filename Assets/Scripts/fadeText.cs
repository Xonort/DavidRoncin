using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadeText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text=gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Color cl = text.color;
        cl.a -= 0.01f;
        GetComponent<Text>().color = cl;
        if (cl.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
