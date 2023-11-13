using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("CanvasEscaped").GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                GameObject.Find("CanvasEscaped").GetComponent<Canvas>().enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                GameObject.Find("CanvasEscaped").GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
