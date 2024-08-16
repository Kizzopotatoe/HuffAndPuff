using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
        }
    }
}
