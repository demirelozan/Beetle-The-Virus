using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorial;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
