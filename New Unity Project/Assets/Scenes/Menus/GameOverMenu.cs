using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    public GameObject continueButton;
    public int continueButtonTimeout = 5;
    public Text continueText;
    private int timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = continueButtonTimeout;
        InvokeRepeating("decreaseTime", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ContinueRoutine());
    }


    public void Continue()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void decreaseTime()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= 1;
        }
    }

    private IEnumerator ContinueRoutine()
    {
        continueText.text = "Continue (" + timeRemaining + ")";
        yield return new WaitForSeconds(continueButtonTimeout);
        continueButton.GetComponent<Button>().interactable = false;
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
