using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string lvl1;
    public string lvl2;
    public string lvl3;
    public string lvl4;
    public string lvl5;
    public string lvl6;
    public string returnMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene(lvl1); //Loads level 1
    }

    public void Level2()
    {
        SceneManager.LoadScene(lvl2); //Loads level 2
    }

    public void Level3()
    {
        SceneManager.LoadScene(lvl3); //Loads level 3
    }

    public void Level4()
    {
        SceneManager.LoadScene(lvl4); //Loads level 4
    }

    public void Level5()
    {
        SceneManager.LoadScene(lvl5); //Loads level 5
    }

    public void Level6()
    {
        SceneManager.LoadScene(lvl6); //Loads level 6
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(returnMainMenu); //Loads Main Menu
    }
}
