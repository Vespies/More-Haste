using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenRules()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene(2);
    }
}
