using UnityEngine;

public class GoalManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.completedLevelMenu.SetActive(true);
            GameManager.Instance.hasCompletedLevel = true;
            Time.timeScale = 0;
        }
    }
}
