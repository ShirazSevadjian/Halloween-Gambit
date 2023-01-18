using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Level1Player1()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Level1Player2()
    {
        SceneManager.LoadScene("MainScene2Player");
    }

    public void Level2Player1()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level2Player2()
    {
        SceneManager.LoadScene("Level2Player2");
    }


    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
