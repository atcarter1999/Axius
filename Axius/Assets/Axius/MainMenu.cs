using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelSelector;
    public string Controls;
    // Use this for initialization
    void Start()
    {
        
    }
    //Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelSelector); //Loads level
    }

    public void Control()
    {
        SceneManager.LoadScene(Controls);
    }
    public void QuitGame()
    {
        Application.Quit();     //Quits application
    }

    
}
