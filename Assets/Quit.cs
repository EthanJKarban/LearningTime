using System;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void closeGame()
    {
        Console.WriteLine("The game is ending, just like your hopes and dreams.");
        Application.Quit();
        
    }
}
