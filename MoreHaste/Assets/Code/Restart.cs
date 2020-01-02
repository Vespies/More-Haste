using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] Text rt;
    // Start is called before the first frame update
    void Start()
    {
        //The text starts as transparent
        rt.color = Color.clear;
    }
    void Update()
    {
        //Pressing r reloads the scene
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void EndGame()
    {
        //Once end game is called, the text appears
        rt.color = Color.green;
    }
}
