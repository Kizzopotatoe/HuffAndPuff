using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorial;
    
    void OnTriggerEnter(Collider other)
    {
        tutorial.SetActive(false);
        Destroy(this);
    }
}
