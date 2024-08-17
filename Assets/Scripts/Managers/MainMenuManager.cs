using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Play()
    {     
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
