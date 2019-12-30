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
        rt.color = Color.clear;
    }
    void Update()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void EndGame()
    {
        rt.color = Color.green;
    }
}
