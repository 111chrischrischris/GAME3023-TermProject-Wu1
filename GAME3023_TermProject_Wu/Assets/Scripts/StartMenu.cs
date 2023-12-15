using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;


    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void PlayGame()
    {
        FadeToLevel(1);
    }

    public void ContinueGame()
    {
        SavingSystem.SaveStart = true;
        FadeToLevel(1);
    }
    
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
