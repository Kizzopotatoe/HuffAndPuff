using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject completedLevelMenu;
    public bool hasCompletedLevel = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        // Get the active scenes build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there is a next scene available
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene 
            SceneManager.LoadScene(currentSceneIndex++);
        }
        else
        {
            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);

            Debug.Log("No new scene to reload");
        }

        Time.timeScale = 1;
    }
}

