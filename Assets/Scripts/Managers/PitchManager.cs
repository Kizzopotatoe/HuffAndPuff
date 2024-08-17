using UnityEngine;

public class PitchManager : MonoBehaviour
{
    public AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            source.pitch = 2;
        }
    }
}
