using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenRules()
    {
        //Loads scene number 1
        SceneManager.LoadScene(1);
    }
    public void OpenGame()
    {
        //Loads scene number 2
        SceneManager.LoadScene(2);
    }
}
