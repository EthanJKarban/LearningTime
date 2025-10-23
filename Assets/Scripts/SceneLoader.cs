using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
   
    
    void Start()
    {
        
    }

    public void Loading()
    {
        SceneManager.LoadScene(sceneName);
        Console.WriteLine("You are now loading" + sceneName,", don't forget to leave your patience at the door.");
    }

    public void closeGame()
    {
        Application.Quit();
    }
}

